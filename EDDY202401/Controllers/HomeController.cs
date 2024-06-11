using EDDY202401.Models;
using Microsoft.AspNetCore.Mvc;

namespace EDDY202401.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> IndexAsync(bool? filter)
        {
            DigitsViewModel? result = new DigitsViewModel();
            string url = "http://localhost:5165/api/Digits";

            if (filter.HasValue)
            {
                url += $"?filter={filter.Value}";
            }

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(url);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await httpClient.GetAsync(url);
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
