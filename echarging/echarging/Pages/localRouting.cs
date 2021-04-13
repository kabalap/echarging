using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Itinero;
using Itinero.IO.Osm;
using Itinero.Osm.Vehicles;


namespace echarging.Pages
{
    public class localRouting
    {
        public void createRouting()
        {
            /*
            // load some routing data and build a routing network.
            var routerDb = new RouterDb();
            using (var stream = new FileInfo(@"/Users/Kasper/Desktop/osm/output/routing.routerdb").OpenRead())
            {
                routerDb = RouterDb.Deserialize(stream, RouterDbProfile.NoCache); // create the network for cars only.
            }

            // create a router.
            var router = new Router(routerDb);

// get a profile.
            var profile = Vehicle.Car.Fastest(); // the default OSM car profile.

// create a routerpoint from a location.
// snaps the given location to the nearest routable edge.
            var start = router.Resolve(profile, 51.26797020271655f, 4.801905155181885f);
            var end = router.Resolve(profile, 51.26797020271655f, 4.801905155181885f);

// calculate a route.
            var route = router.Calculate(profile, start, end);
            using (var writer = new StreamWriter(@"/Users/Kasper/Desktop/osm/output/route.geojson"))
            {
                route.WriteGeoJson(writer);
            }
            */
        }
    }
}
