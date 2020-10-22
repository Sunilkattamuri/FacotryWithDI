using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecast.CrossCutting;
using WeatherForecastModels;

namespace WeatherForecast.DAL
{
    public class PollutionDataDAL : IWeatherDAL 
    {
        private IFetchData _fetchData;

        

        /// <summary>
        /// Using Dependency Injection to inject the api data
        /// </summary>
        /// <param name="getApi"></param>
        public PollutionDataDAL(IFetchData getApi)
        {
            _fetchData = getApi;
        }

        public async Task<Response> Get(Dictionary<string,string> parameters )
        {
            var apiResponse = await _fetchData.GetDataAsync(parameters);
            var result = apiResponse.Contains("message") ? JsonConvert.DeserializeObject<Response>(apiResponse) :
                  JsonConvert.DeserializeObject<PollutionDetailsResponse>(apiResponse);
            if (string.IsNullOrEmpty(result.Message) && string.IsNullOrEmpty(result.Cod))
            {
                result.Cod = "200";
                result.Message = "API Request Success";
            }
            return result;
          
        }
    }
}
