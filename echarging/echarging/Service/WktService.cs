using ProjNet.CoordinateSystems;
using ProjNet.CoordinateSystems.Transformations;
using ProjNet.IO.CoordinateSystems;

namespace echarging.Service
{
    public class WktService
    {
        public ICoordinateTransformation WorldToDk()
        {
            string path1 = @"C:\Users\Kasper\Desktop\echarging\echarging\echarging\wkt84DK.txt";
            string wktDK = System.IO.File.ReadAllText(path1);
            var csDK = CoordinateSystemWktReader.Parse(wktDK) as CoordinateSystem;

            string path = @"C:\Users\Kasper\Desktop\echarging\echarging\echarging\wkt84test.txt";
            string wktWorld = System.IO.File.ReadAllText(path);
            var csWorld = CoordinateSystemWktReader.Parse(wktWorld) as CoordinateSystem;

            CoordinateTransformationFactory ctfac = new CoordinateTransformationFactory();
            ICoordinateTransformation trans = ctfac.CreateFromCoordinateSystems(csWorld, csDK);
            return trans;
        }

        public ICoordinateTransformation DkToWorld()
        {
            string path1 = @"C:\Users\Kasper\Desktop\echarging\echarging\echarging\wkt84DK.txt";
            string wktDK = System.IO.File.ReadAllText(path1);
            var csDK = CoordinateSystemWktReader.Parse(wktDK) as CoordinateSystem;

            string path = @"C:\Users\Kasper\Desktop\echarging\echarging\echarging\wkt84test.txt";
            string wktWorld = System.IO.File.ReadAllText(path);
            var csWorld = CoordinateSystemWktReader.Parse(wktWorld) as CoordinateSystem;

            CoordinateTransformationFactory ctfac = new CoordinateTransformationFactory();
            ICoordinateTransformation trans = ctfac.CreateFromCoordinateSystems(csDK, csWorld);
            return trans;
        }
    }
}
