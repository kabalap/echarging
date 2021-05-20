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

namespace echarging.Service
{
    public class RouterService
    {
        public Router Router { get; private set; }

        public RouterService()
        {
            // Initializing the router is expensive, ensure it's only done once
            using var stream = new FileInfo(@"/root/osm/output/routing.routerdb").OpenRead();
            var routerDb = RouterDb.Deserialize(stream); // create the network for cars only.

            Router = new Router(routerDb);
        }
    }
}
