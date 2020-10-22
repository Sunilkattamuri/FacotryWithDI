using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastModels;

namespace WeatherAppBL
{
    public interface IWeatherBL
    {
        Task<Response> GetDataAsync(Dictionary<string, string> parameters);
    }
}
