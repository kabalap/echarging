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
using NetTopologySuite.Features;

namespace echarging.Pages.Classes
{
    public class RouteProjection
    {

        public Geometry buffer(FeatureCollection features, ICoordinateTransformation trans)
        {
            var coordinates = features.Select(x => x.Geometry)
            .SelectMany(x => x.Coordinates)
            .Select(x =>
            {
                 var transformed = trans.MathTransform.Transform(new[] { x.X, x.Y });
                 return new Coordinate(transformed[0], transformed[1]);
            })
            .ToArray();
            var lineString = GeometryFactory.Default.CreateLineString(coordinates);
            return lineString.Buffer(200);
        }
    }
}
