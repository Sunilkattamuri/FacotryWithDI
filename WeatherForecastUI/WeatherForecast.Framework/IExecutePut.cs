using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.CrossCutting
{
    /// <summary>
    /// Using Interface seggregation & SRP, Creating sep interfaces for Get/POST/PUT
    /// </summary>
    public interface IExecutePut
    {
        Task<string> ExecutePut(Dictionary<string, string> parameters);
    }
}
