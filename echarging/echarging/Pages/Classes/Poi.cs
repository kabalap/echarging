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
    public class Poi
    {
        public List<Double[]> poi(Geometry bufferedData, List<Point> chargingStations, ICoordinateTransformation dkToWgs84)
        {
            var poi = new List<double[]>();
            var prepared = NetTopologySuite.Geometries.Prepared.PreparedGeometryFactory.Prepare(bufferedData);
            foreach (Point p in chargingStations)
            {
                if (prepared.Intersects(p))
                    poi.Add(dkToWgs84.MathTransform.Transform(new[] { p.X, p.Y }));
            }
            return poi;
        }
    }
}
