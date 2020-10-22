using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAppApi.ViewModels
{
    public class PollutionResponse:Response
    {
        public string Time { get; set; }
        public string Location { get; set; }

        public List<PollutionDetails> PollutionDetails { get; set; }

      

    }
}
