using System.IO;
using Itinero;

namespace echarging.Service
{
    public class RouterService
    {
        public Router Router { get; private set; }

        public RouterService()
        {
            // Initializing the router is expensive, ensure it's only done once
            using var stream = new FileInfo(@"C:\Users\Kasper\Desktop\osm\output\routing.routerdb").OpenRead();
            var routerDb = RouterDb.Deserialize(stream); // create the network for cars only.

            Router = new Router(routerDb);
        }
    }
}
