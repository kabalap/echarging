using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.IO;
using Itinero;
using Itinero.IO.Osm;
using Itinero.Osm.Vehicles;



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
            using var stream = new FileInfo(@"/Users/kasperhansen/Desktop/osm/output/routing.routerdb").OpenRead();
            var routerDb = RouterDb.Deserialize(stream, RouterDbProfile.NoCache); // create the network for cars only.
            // create a router.
            var router = new Router(routerDb);

            // get a profile.
            var profile = Vehicle.Car.Fastest(); // the default OSM car profile.

            // create a routerpoint from a location.
            // snaps the given location to the nearest routable edge.
            var start = router.Resolve(profile, 55.408327f, 11.370692f);
            var end = router.Resolve(profile, 55.663868644187815f, 12.412232911856966f);

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
                var routing = route.ToJson();
                return routing; 
            }
        }
        */
    }
}