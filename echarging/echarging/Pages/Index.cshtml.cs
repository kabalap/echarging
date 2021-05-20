using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using Itinero;
using Itinero.Geo;
using ProjNet.CoordinateSystems.Transformations;
using echarging.Service;
using System.Threading.Tasks;
using Itinero.Profiles;
using echarging.Pages.Classes;

namespace echarging.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly LocationService _locationService;
        private readonly RouterService _routerService;
        private readonly ChargerProjectService _chargerService;
        private readonly WktService _wktService;

        public IndexModel(ILogger<IndexModel> logger, LocationService locationService, RouterService routerService, ChargerProjectService chargerService, WktService wktService)
        {
            _logger = logger;
            _locationService = locationService;
            _routerService = routerService;
            _chargerService = chargerService;
            _wktService = wktService;
        }

        public void OnGet()
        {
            ViewData["route"] = "{}";
        }

        private async Task<RouterPoint> getRouterPoint(Router router, Profile profile, String location)
        {
            var position = await _locationService.getLocation(location);
            if (position == null)
                return null;

            return router.Resolve(profile, (float) position.X, (float) position.Y);
        }

        public async Task<IActionResult> OnPostLocations(string startPosition, string endPosition)
        {
            // get a profile.
            var profile = Itinero.Osm.Vehicles.Vehicle.Car.Fastest(); // the default OSM car profile.

            // Get start and destination
            // snaps the given location to the nearest routable edge.
            var start = await getRouterPoint(_routerService.Router, profile, startPosition);
            if (start == null)
                return Page();

            var end = await getRouterPoint(_routerService.Router, profile, endPosition);
            if (end == null)
                return Page();

            // Creates transformer used to project data from world to dk coordinatesystem
            ICoordinateTransformation trans = _wktService.WorldToDk();

            // Convert from Itinero data format to NTS format such the data can be projected and buffered
            var calculatedRoute = _routerService.Router.Calculate(profile, start, end);
            var features = calculatedRoute.ToFeatureCollection();

            // Projects route and creates lineString with buffer
            var bufferedData = RouteProjection.getBufferedLineString(features, trans);

            //Projects each charger location 
            var chargingStations = _chargerService.chargingStations(trans);

            // creates tranformer used to project data from dk to world coordinatesystem
            ICoordinateTransformation dkToWgs84 = _wktService.DkToWorld();

            // Checks if each chargingstation intersects with buffereddata and projects chargingsstation back to original coordinatesystem if they do
            var intersectingPoints = PointIntersectionUtility.getIntersectingPoints(bufferedData, chargingStations, dkToWgs84);

            // calculate a route.
            ViewData["poi"] = intersectingPoints;
            ViewData["startposition"] = startPosition;
            ViewData["destination"] = endPosition;
            ViewData["route"] = calculatedRoute.ToGeoJson();

            return Page();

        }
    }
}