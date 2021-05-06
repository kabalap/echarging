using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace echarging.Pages
{
    public class ChargerLocation
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Geometry
        {
            public string type { get; set; }
            public List<List<double>> coordinates { get; set; }
        }

        public class Properties
        {
            public string vejnavn { get; set; }
            public string husnr { get; set; }
            public string betalingszone { get; set; }
            public string ladestandertype { get; set; }
            public int antal_udtag { get; set; }
            public string position { get; set; }
            public int ladestander_id { get; set; }
            public string @operator { get; set; }
            public DateTime? faerdigmeldingsdato { get; set; }
            public string bem { get; set; }
            public string name { get; set; }
        }

        public class Feature
        {
            public string type { get; set; }
            public string id { get; set; }
            public Geometry geometry { get; set; }
            public string geometry_name { get; set; }
            public Properties properties { get; set; }
        }

        public class Crs
        {
            public string type { get; set; }
            public Properties properties { get; set; }
        }

        public class Root
        {
            public string type { get; set; }
            public int totalFeatures { get; set; }
            public List<Feature> features { get; set; }
            public Crs crs { get; set; }
        }

    }
}
