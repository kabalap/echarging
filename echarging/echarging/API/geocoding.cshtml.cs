using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Reminiscence.Collections;

namespace echarging.API
{
    public class geocoding : PageModel
    {
        [Microsoft.AspNetCore.Mvc.HttpGet("{address}")]
        public async Task <IActionResult> GetDetailsAsync(string address)
        {
            var client = new HttpClient();

            var result = await client.GetAsync("https://api.traveltimeapp.com/v4/geocoding/search?query=`");
            var content = result.Content.ToString();
            dynamic details = JsonConvert.DeserializeObject(content);
            if (details == null)
                return NotFound();

        }
        
    }
}