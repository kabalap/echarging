using NetTopologySuite.Geometries;
using System.Collections.Generic;
using ProjNet.CoordinateSystems.Transformations;

namespace echarging.Service
{
    public class PointIntersectionUtility
    {
        public static List<double[]> getIntersectingPoints(Geometry bufferedData, List<Point> chargingStations, ICoordinateTransformation dkToWgs84)
        {
            var pointsOfInterest = new List<double[]>();
            var prepared = NetTopologySuite.Geometries.Prepared.PreparedGeometryFactory.Prepare(bufferedData);
            foreach (Point p in chargingStations)
            {
                if (prepared.Intersects(p))
                    pointsOfInterest.Add(dkToWgs84.MathTransform.Transform(new[] { p.X, p.Y }));
            }

            return pointsOfInterest;
        }
    }
}
