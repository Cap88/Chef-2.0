using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChefInternational.Pages.Map
{
    public class IndexModel : PageModel
    {
        static HttpClient client = new HttpClient();
        private const string YOUR_APP_ID = "0216fa0a";
        private const string YOUR_APP_KEY = "e0b5b72adaff004caf7f9f0d92885691";
        
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnGetFetchRecipesAsync()
        {
            string country = HttpContext.Request.Query["country"];
            string pageIndex = HttpContext.Request.Query["pi"];

            if (!String.IsNullOrEmpty(country) && !String.IsNullOrEmpty(pageIndex))
            {
                try {
                    string resultsFrom = Convert.ToString(Convert.ToInt32(HttpContext.Request.Query["pi"]) * 10);
                    string resultsTo = Convert.ToString(Convert.ToInt32(resultsFrom) + 10);
                    // needs const
                    var path = "https://api.edamam.com/search?q=" + country + "&app_id=" + YOUR_APP_ID + "&app_key=" + YOUR_APP_KEY + "&from=" + resultsFrom + "&to=" + resultsTo;
                    HttpResponseMessage response = await client.GetAsync(path);

                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(responseBody);

                    return new JsonResult(json);
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                    return StatusCode(404);
                }
            }
            return StatusCode(404);
            // add msg
        }
    }
}