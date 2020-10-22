using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastUI.Models
{
    public class PollutionResponse:Response
    {
        public string Precision { get; set; }
        public string Pressure { get; set; }
        public string Value { get; set; }
    }
}
