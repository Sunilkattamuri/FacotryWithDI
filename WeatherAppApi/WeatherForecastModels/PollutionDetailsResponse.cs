using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastModels
{
    public class PollutionDetailsResponse:Response
    {
        public string Time { get; set; }
        public string Location { get; set; }

        public List<PollutionDetails> PollutionDetails { get; set; }
    }
}
