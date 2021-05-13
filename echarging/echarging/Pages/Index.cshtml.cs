using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.IO;
using System;
using Itinero;
using Itinero.Geo;
using Itinero.Osm.Vehicles;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using ProjNet;
using ProjNet.CoordinateSystems;
using System.Collections.Generic;
using ProjNet.CoordinateSystems.Transformations;
using ProjNet.IO.CoordinateSystems;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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
            using (var stream = new FileInfo(@"Users/Kasper/Desktop/osm/output/routing.routerdb").Open(FileMode.Create))
            {
                var routerDb = new RouterDb();
                routerDb.Serialize(stream);
            }



            return Page();

        }

        public double[] ToDoubleArray(Coordinate[] coordinates)
        {
            throw new NotImplementedException();
        }


        public IActionResult OnPostWin(string startposition, string destination)
        {
            // load some routing data and build a routing network.
            using var stream = new FileInfo(@"C:\Users\Kasper\Desktop\osm\output\routing.routerdb").OpenRead();
            var routerDb = RouterDb.Deserialize(stream); // create the network for cars only.
            // create a router.
            var router = new Router(routerDb);

            // get a profile.
            var profile = Vehicle.Car.Fastest(); // the default OSM car profile.

            // create a routerpoint from a location.
            // snaps the given location to the nearest routable edge.
            var start = router.Resolve(profile, 55.681797f, 12.605089f);
            var end = router.Resolve(profile, 55.663868644187815f, 12.412232911856966f);

            string path1 = @"C:\Users\Kasper\Desktop\wkt84DK.txt";
            string wktDK = System.IO.File.ReadAllText(path1);
            var csDK = CoordinateSystemWktReader.Parse(wktDK) as CoordinateSystem;

            string path = @"C:\Users\Kasper\Desktop\wkt84test.txt";
            string wktWorld = System.IO.File.ReadAllText(path);
            var csWorld = CoordinateSystemWktReader.Parse(wktWorld) as CoordinateSystem;

            CoordinateTransformationFactory ctfac = new CoordinateTransformationFactory();
            ICoordinateTransformation trans = ctfac.CreateFromCoordinateSystems(csWorld, csDK);


            var chargingStations = new List<Point>();
            using (StreamReader reader = System.IO.File.OpenText(@"C:\Users\Kasper\Desktop\echarging\echarging\echarging\locations\location.geojson"))
            {
                JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));

                JArray fitter = (JArray)o["features"];
                foreach (var fit in fitter)
                {
                    JArray coords = (JArray)fit["geometry"]["coordinates"][0];

                    var transvestit = trans.MathTransform.Transform(new[] { Double.Parse(coords[0].ToString()), Double.Parse(coords[1].ToString()) });
                    chargingStations.Add(new Point(transvestit[0], transvestit[1]));
                }
            }
/*
            var tranformedList = trans.MathTransform.TransformList(chargingStations);
            var transformedPoints = new List<Point>();

            foreach (double[] d in tranformedList)
            {
                transformedPoints.Add(new Point(d[0], d[1]));
            }*/

            // Convert from Itinero data format to NTS format such the data can be projected and buffered
            var features = router.Calculate(profile, start, end).ToFeatureCollection();
            
            var coordinates = features.Select(x => x.Geometry)
               .SelectMany(x => x.Coordinates)
               .Select(x =>
               {
                   var transformed = trans.MathTransform.Transform(new[] { x.X, x.Y });
                   return new Coordinate(transformed[0], transformed[1]);
               })
               .ToArray();
            var lineString = GeometryFactory.Default.CreateLineString(coordinates);
            var bufferedData = lineString.Buffer(200);
            

            var done = new List<double[]>();
            var prepared = NetTopologySuite.Geometries.Prepared.PreparedGeometryFactory.Prepare(bufferedData);
            ICoordinateTransformation dkToWgs84 = ctfac.CreateFromCoordinateSystems(csDK, csWorld);
            foreach (Point p in chargingStations)
            {
                if (prepared.Intersects(p))
                    done.Add(dkToWgs84.MathTransform.Transform(new[] { p.X, p.Y }));
            }



            // calculate a route.
            ViewData["poi"] = done;
            ViewData["startposition"] = startposition;
            ViewData["destination"] = destination;
            ViewData["route"] = router.Calculate(profile, start, end).ToGeoJson();
            return Page();


        }


    }
}