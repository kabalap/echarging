using System.Linq;
using NetTopologySuite.Geometries;
using ProjNet.CoordinateSystems.Transformations;
using NetTopologySuite.Features;

namespace echarging.Pages.Classes
{
    public class RouteProjection
    {
        public static Geometry getBufferedLineString(FeatureCollection features, ICoordinateTransformation trans, double distance = 200)
        {
            // Project all coordinates in FeatureCollection
            var coordinates = features.Select(x => x.Geometry)
                .SelectMany(x => x.Coordinates)
                .Select(x =>
                {
                     var transformed = trans.MathTransform.Transform(new[] { x.X, x.Y });
                     return new Coordinate(transformed[0], transformed[1]);
                })
                .ToArray();

            // Get lineString with buffer of specified distance
            return GeometryFactory.Default.CreateLineString(coordinates).Buffer(distance);
        }
    }
}
