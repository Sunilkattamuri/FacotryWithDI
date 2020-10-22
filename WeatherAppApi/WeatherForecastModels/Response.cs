using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecastModels
{
    public class Response
    {
        public string Message { get; set; }
        public string Cod { get; set; }
    }

    public enum RequestTypes
    {
        Get,
        Put,
        Post
    }
}
