using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.IO;
using Itinero;
using Itinero.Geo;
using Itinero.Osm.Vehicles;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
/*
using ProjNet;
using ProjNet.CoordinateSystems;
using System.Collections.Generic;
using ProjNet.CoordinateSystems.Transformations;
using GeoAPI;
using GeoAPI.CoordinateSystems.Transformations;
*/

namespace echarging.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        

        public void OnGet()
        {
            ViewData["route"] = "{}";
        }
        /*
        public IActionResult OnPostGo()
        {
            var routerDb = RouterDb.Deserialize(stream, RouterDbProfile.NoCache);
            routerDb.AddContracted(routerDb.GetSupportedProfile("car"));
            return Page();
        }
        */

        public IActionResult OnPostGo()
        {
            /*
            // load some routing data and build a routing network.
            var routerDb = new RouterDb();
            using (var stream = new FileInfo(@"Users/Kasper/Desktop/osm/denmark-latest.osm.pbf").OpenRead())
            {
                // create the network for cars only.
                routerDb.LoadOsmData(stream, Vehicle.Car); 
            }
*/

            // write the routerdb to disk.
            using (var stream = new FileInfo(@"Users/kasperhansen/Desktop/osm/output/routing.routerdb").Open(FileMode.Create))
            {
                var routerDb = new RouterDb();
                    routerDb.Serialize(stream);
            }
            
            

            return Page(); 
            
        }

        public IActionResult OnPostWin()
        {
            // load some routing data and build a routing network.
            using var stream = new FileInfo(@"/Users/Kasper/Desktop/osm/output/routing.routerdb").OpenRead();
            var routerDb = RouterDb.Deserialize(stream, RouterDbProfile.NoCache); // create the network for cars only.
            // create a router.
            var router = new Router(routerDb);  

            // get a profile.
            var profile = Vehicle.Car.Fastest(); // the default OSM car profile.

            // create a routerpoint from a location.
            // snaps the given location to the nearest routable edge.
            var start = router.Resolve(profile, 55.408327f, 11.370692f);
            var end = router.Resolve(profile, 55.663868644187815f, 12.412232911856966f);
            
            // Convert from Itinero data format to NTS format such the data can be projected and buffered
            var features = router.Calculate(profile, start, end).ToFeatureCollection();
            // Remember to project data before buffer
            
            /*
             string wktDK = "PROJCS[\"ETRS89 / DKTM4\",GEOGCS[\"ETRS89\",DATUM[\"European_Terrestrial_Reference_System_1989\"," +
                 "SPHEROID[\"GRS 1980\",6378137,298.257222101," +
                 "AUTHORITY[\"EPSG\",\"7019\"]],TOWGS84[0,0,0,0,0,0,0],AUTHORITY[\"EPSG\",\"6258\"]],PRIMEM[\"Greenwich\",0," +
                 "AUTHORITY[\"EPSG\",\"8901\"]],UNIT[\"degree\",0.0174532925199433," +
                 "AUTHORITY[\"EPSG\",\"9122\"]],AUTHORITY[\"EPSG\",\"4258\"]],PROJECTION[\"Transverse_Mercator\"]," +
                 "PARAMETER[\"latitude_of_origin\",0],PARAMETER[\"central_meridian\",15]," +
                 "PARAMETER[\"scale_factor\",1],PARAMETER[\"false_easting\",800000],PARAMETER[\"false_northing\",-5000000]," +
                 "UNIT[\"metre\",1,AUTHORITY[\"EPSG\",\"9001\"]],AXIS[\"Easting\",EAST],AXIS[\"Northing\",NORTH]," +
                 "AUTHORITY[\"EPSG\",\"4096\"]]";
             GeoAPI.CoordinateSystems.ICoordinateSystem csDK =    
                 ProjNet.Converters.WellKnownText.CoordinateSystemWktReader.Parse(wktDK) as GeoAPI.CoordinateSystems.ICoordinateSystem;

             string wktWorld = "GEOGCS[\"WGS 84\",DATUM[\"WGS_1984\",SPHEROID[\"WGS 84\",6378137,298.257223563," +
                 "AUTHORITY[\"EPSG\",\"7030\"]],AUTHORITY[\"EPSG\",\"6326\"]]," +
                 "PRIMEM[\"Greenwich\",0,AUTHORITY[\"EPSG\",\"8901\"]],UNIT[\"degree\",0.0174532925199433," +
                 "AUTHORITY[\"EPSG\",\"9122\"]],AUTHORITY[\"EPSG\",\"4326\"]]";
             GeoAPI.CoordinateSystems.ICoordinateSystem csWorld =    
                 ProjNet.Converters.WellKnownText.CoordinateSystemWktReader.Parse(wktWorld) as GeoAPI.CoordinateSystems.ICoordinateSystem;

             CoordinateTransformationFactory ctfac = new CoordinateTransformationFactory();
             ICoordinateTransformation trans = ctfac.CreateFromCoordinateSystems(csDK, csWorld);
             double[] fromPoint = new double[] { -16.1, 32.88 };
             double[] toPoint = trans.MathTransform.Transform(fromPoint);
            */
            
            var coordinates = features.Select(x => x.Geometry)
                .SelectMany(x => x.Coordinates)
                .ToArray();
            var lineString = GeometryFactory.Default.CreateLineString(coordinates);
            var bufferedData = lineString.Buffer(200);
            var json = System.IO.File.ReadAllText(
                "/Users/kasper/Desktop/echarging/echarging/echarging/Pages/charge.json");
            var reader = new GeoJsonReader();
            var chargingStations = reader.Read<FeatureCollection>(json)
                .Select(x => x.Geometry)
                .Where(x => x.Intersects(bufferedData));

            //var poi = o2.Where(o2 => o2.Intersects(bufferedData));
        
        
            /*
            using (StreamReader r = new StreamReader("charge.json"))
            {
                string json = r.ReadToEnd();
            }
            */




            // calculate a route.
            ViewData["route"] = router.Calculate(profile, start, end).ToGeoJson();
            return Page();
        }
        
        /*
        public string Routing()
        {
            // load some routing data and build a routing network.
            using (var stream = new FileInfo(@"/Users/Kasper/Desktop/osm/output/routing.routerdb").OpenRead())
            {
                var routerDb = RouterDb.Deserialize(stream, RouterDbProfile.NoCache); // create the network for cars only.
                // create a router.
                var router = new Router(routerDb);

                // get a profile.
                var profile = Vehicle.Car.Fastest(); // the default OSM car profile.

                // create a routerpoint from a location.
                // snaps the given location to the nearest routable edge.
                var start = router.Resolve(profile, 57.0408543119709f, 9.946265898566171f);
                var end = router.Resolve(profile, 55.663868644187815f, 12.412232911856966f);

                // calculate a route.
                var route = router.Calculate(profile, start, end);
                using (var writer = new StreamWriter(@"/Users/Kasper/Desktop/osm/output/route.geojson"))
                {
                    route.WriteGeoJson(writer);
                }

                string allText = System.IO.File.ReadAllText(@"/Users/Kasper/Desktop/osm/output/route.geojson");
                object jsonObject = JsonConvert.DeserializeObject(allText);
                return jsonObject;

            }
        }
        */
    }
}