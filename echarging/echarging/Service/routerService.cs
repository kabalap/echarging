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
    public class routerService
    {
        public Router router()
        {
            using var stream = new FileInfo(@"C:\Users\Kasper\Desktop\osm\output\routing.routerdb").OpenRead();
            var routerDb = RouterDb.Deserialize(stream); // create the network for cars only.
            return new Router(routerDb);
        }
    }
}
