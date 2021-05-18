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
    public class WktService
    {

        public ICoordinateTransformation WorldToDk()
        {
            string path1 = @"/root/wkt/wkt84DK.txt";
            string wktDK = System.IO.File.ReadAllText(path1);
            var csDK = CoordinateSystemWktReader.Parse(wktDK) as CoordinateSystem;

            string path = @"/root/wkt/wkt84World.txt";
            string wktWorld = System.IO.File.ReadAllText(path);
            var csWorld = CoordinateSystemWktReader.Parse(wktWorld) as CoordinateSystem;

            CoordinateTransformationFactory ctfac = new CoordinateTransformationFactory();
            ICoordinateTransformation trans = ctfac.CreateFromCoordinateSystems(csWorld, csDK);
            return trans;
        }

        public ICoordinateTransformation DkToWorld()
        {
            string path1 = @"/root/wkt/wkt84DK.txt";
            string wktDK = System.IO.File.ReadAllText(path1);
            var csDK = CoordinateSystemWktReader.Parse(wktDK) as CoordinateSystem;

            string path = @"/root/wkt/wkt84World.txt";
            string wktWorld = System.IO.File.ReadAllText(path);
            var csWorld = CoordinateSystemWktReader.Parse(wktWorld) as CoordinateSystem;

            CoordinateTransformationFactory ctfac = new CoordinateTransformationFactory();
            ICoordinateTransformation trans = ctfac.CreateFromCoordinateSystems(csDK, csWorld);
            return trans;
        }
    }
}
