using EDDY202401.Models;
using Microsoft.AspNetCore.Mvc;

namespace EDDY202401.Controllers
{
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();

        public async Task<IActionResult> IndexAsync()
        {
            DigitsViewModel result = new DigitsViewModel();
            string url = "http://localhost:5165/api/Digits";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<DigitsViewModel>(data);
                }
            }

            return View(result);
        }
    }
}
