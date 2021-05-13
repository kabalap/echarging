using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.IO;
using System;
using Itinero;
using Itinero.Geo;
using Itinero.Osm.Vehicles;
using NetTopologySuite.Geometries;
using ProjNet.CoordinateSystems;
using System.Collections.Generic;
using ProjNet.CoordinateSystems.Transformations;
using ProjNet.IO.CoordinateSystems;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using echarging.Service;
using System.Threading.Tasks;
using Itinero.Profiles;

namespace echarging.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly LocationService _locationService;

        public IndexModel(ILogger<IndexModel> logger, LocationService locationService)
        {
            _logger = logger;
            _locationService = locationService;
        }


        public void OnGet()
        {
            ViewData["route"] = "{}";
        }

        public double[] ToDoubleArray(Coordinate[] coordinates)
        {
            throw new NotImplementedException();
        }

        private async Task<RouterPoint> getRouterPoint(Router router, Profile profile, String location)
        {
            var position = await _locationService.getLocation(location);
            if (position == null)
                return null;

            return router.Resolve(profile, (float) position.X, (float) position.Y);
        }

        public async Task<IActionResult> OnPostWin(string startPosition, string endPosition)
        {
            // load some routing data and build a routing network.
            using var stream = new FileInfo(@"C:\Users\Kasper\Desktop\osm\output\routing.routerdb").OpenRead();
            var routerDb = RouterDb.Deserialize(stream); // create the network for cars only.

            // create a router.
            var router = new Router(routerDb);

            // get a profile.
            var profile = Itinero.Osm.Vehicles.Vehicle.Car.Fastest(); // the default OSM car profile.

            // Get start and destination
            // snaps the given location to the nearest routable edge.
            var start = await getRouterPoint(router, profile, startPosition);
            if (start == null)
                return Page();

            var end = await getRouterPoint(router, profile, endPosition);
            if (end == null)
                return Page();

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
            ViewData["startposition"] = startPosition;
            ViewData["destination"] = endPosition;
            ViewData["route"] = router.Calculate(profile, start, end).ToGeoJson();
            return Page();


        }


    }
}