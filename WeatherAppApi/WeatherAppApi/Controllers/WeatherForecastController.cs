using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WeatherAppApi.ViewModels;
using WeatherAppBL;
using WeatherForecast.Framework;

namespace WeatherAppApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;

        }

        [HttpGet]
        public async Task<WeatherForecastModels.Response> Get(double latitude, double longitude, DateTime dateTime, string apiKey)
        {
           
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>() {
                    {"Latitude",latitude.ToString() },
                    {"Longitude",longitude.ToString() },
                    {"DateTime",dateTime.ToString() },
                    {"AppId",apiKey }
                };
               
                BaseFactory blData = new BaseFactory(new BLFactory());
                var blLayer = (IWeatherBL)blData.CreateNewInstance(typeof(PollutionDataBL));
                return await blLayer.GetDataAsync(parameters);
                
               
            }
            catch (Exception ex)
            {
                return new WeatherForecastModels.Response() { Cod = "405", Message = ex.Message };
            }
           
        }


        private void temp()
        {
            //string url = string.Format(Configuration["WeatherAppUrl"], latitude, longitude, dateTime.ToString("yyyy-MM-ddTHH:mm:ss"), apiKey);
            //using HttpClient httpClient = new HttpClient();
            //using HttpResponseMessage response = await httpClient.GetAsync(url);
            //string apiResponse = await response.Content.ReadAsStringAsync();
            //var result = apiResponse.Contains("message") ? JsonConvert.DeserializeObject<Response>(apiResponse) :
            //      JsonConvert.DeserializeObject<PollutionResponse>(apiResponse);
            //if(string.IsNullOrEmpty(result.Message) && string.IsNullOrEmpty(result.Cod))
            //{
            //    result.Cod = "200";
            //    result.Message = "API Request Success";
            //}
            //return result;
        }



    }
}
