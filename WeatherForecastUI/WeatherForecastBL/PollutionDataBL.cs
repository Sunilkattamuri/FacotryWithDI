using System;
using System.Collections.Generic;
using WeatherForecast.DAL;
using WeatherForecast.Framework;
using WeatherForecastModels;

namespace WeatherAppBL
{
    public class PollutionDataBL :IWeatherBL
    {
        private IWeatherDAL _dal;
         
       
        /// <summary>
        /// Using Dependency injection
        /// </summary>
        /// <param name="weatherDAL"></param>
        public PollutionDataBL(IWeatherDAL weatherDAL)
        {
            _dal = weatherDAL;
        }
        public async System.Threading.Tasks.Task<Response> GetDataAsync(Dictionary<string, string> parameters)
        {
            return await _dal.Get(parameters);
           
           
        }
    }
}
