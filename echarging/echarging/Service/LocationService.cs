using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace echarging.Service
{
    public class LocationService
    {
        public async Task<Point> getLocation(String pointOfInterest)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("X-Application-Id", "ec911051");
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", "4a5c61b68a3b8700c544e98c0941cc9f");
            httpClient.DefaultRequestHeaders.Add("Accept-Language", "en");

            var result = await httpClient.GetAsync($"https://api.traveltimeapp.com/v4/geocoding/search?query={pointOfInterest}");
            var content = await result.Content.ReadAsStringAsync();

            dynamic location = JsonConvert.DeserializeObject(content);
            if (location == null)
                return null;

            if (!(location.features is JArray))
                return null;

            // Return null if no matches on the query
            var features = (JArray) location.features;
            if (features.Count == 0)
                return null;

            // API may return multiple coordinates for one query, just use the first :-)
            var coordinates = features[0]["geometry"]["coordinates"].Reverse().ToArray();

            return new Point(Double.Parse(coordinates[0].ToString()), Double.Parse(coordinates[1].ToString()));
        }
    }
}
