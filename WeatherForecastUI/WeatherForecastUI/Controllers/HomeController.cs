using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WeatherAppBL;
using WeatherForecast.Framework;
using WeatherForecastUI.Models;

namespace WeatherForecastUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration Configuration;

        public HomeController(ILogger<HomeController> logger,IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetPollutionData(double latitude, double longitude, DateTime dateTime)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>() {
                    {"Latitude",latitude.ToString() },
                    {"Longitude",longitude.ToString() },
                    {"DateTime",dateTime.ToString() },
                    {"AppId",Configuration["APIKey"] }
                  
                };

                BaseFactory blData = new BaseFactory(new BLFactory());
                var blLayer = (IWeatherBL)blData.CreateNewInstance(typeof(PollutionDataBL));

                return Json(new { data = JsonConvert.SerializeObject(await blLayer.GetDataAsync(parameters)) });

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void temp()
        {
            //DateTime dateTime = DateTime.Now;

            //string url = string.Format(Configuration["ApiUrl"], latitude, longitude, dateTime, Configuration["APIKey"]);

            //using (HttpClient httpClient = new HttpClient())
            //{
            //    using (HttpResponseMessage response = await httpClient.GetAsync(url))
            //    {
            //        string result = await response.Content.ReadAsStringAsync();
            //        PollutionResponse pollutionData = JsonConvert.DeserializeObject<PollutionResponse>(result);
            //        //  var pollutionData = JsonConvert.DeserializeObject(result);
            //        return Json(new { data = JsonConvert.SerializeObject(pollutionData) });
            //    }
            //}
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
