using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecast.CrossCutting;
using WeatherForecast.Framework;

namespace WeatherForecast.DAL
{
    public class DALFactory:BaseFactory
    {
        public DALFactory()
        {

        }

        public override object CreateNewInstance(Type type)
        {
            if(Type.Equals(type,typeof(PollutionDataDAL)))
            {
                return new PollutionDataDAL(new FetchApiData("http://api.openweathermap.org/pollution/v1/co/{0},{1}/{2}Z.json?appid={3}"));
            }

            return null;
        }
    }
}
