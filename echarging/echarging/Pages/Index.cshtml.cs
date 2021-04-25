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