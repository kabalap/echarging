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
            // load some routing data and build a routing network.
            var routerDb = new RouterDb();
            using (var stream = new FileInfo(@"/root/osm/denmark-latest.osm.pbf").OpenRead())
            {
                // create the network for cars only.
                routerDb.LoadOsmData(stream, Vehicle.Car); 
            }

            // write the routerdb to disk.
            using (var stream = new FileInfo(@"/root/osm/output/routing.routerdb").Open(FileMode.Create))
            {
                routerDb.Serialize(stream);
            }

            return Page(); 
            
        }
    }
}
