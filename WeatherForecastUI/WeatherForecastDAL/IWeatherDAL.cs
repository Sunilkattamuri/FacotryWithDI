using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastModels;

namespace WeatherForecast.DAL
{
    public interface IWeatherDAL
    {
        Task<Response> Get(Dictionary<string, string> parameters);
    }
}
