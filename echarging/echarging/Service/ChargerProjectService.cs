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

namespace echarging.Pages.Classes
{
    public class ChargerProjectService
    {

        public List<Point> chargingStations(ICoordinateTransformation trans)
        {
            var chargingStations = new List<Point>();
            using (StreamReader reader = File.OpenText(@"C:\Users\Kasper\Desktop\echarging\echarging\echarging\locations\location.geojson"))
            {
                JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));

                JArray features = (JArray)o["features"];
                foreach (var feature in features)
                {
                    JArray coords = (JArray)feature["geometry"]["coordinates"][0];

                    var transform = trans.MathTransform.Transform(new[] { Double.Parse(coords[0].ToString()), Double.Parse(coords[1].ToString()) });
                    chargingStations.Add(new Point(transform[0], transform[1]));
                }
            }
            return chargingStations;
        }


    }
}
