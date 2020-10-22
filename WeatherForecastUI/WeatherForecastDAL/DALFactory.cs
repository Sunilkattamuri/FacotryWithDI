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
                return new PollutionDataDAL(new FetchApiData("http://localhost:64228/weatherforecast?latitude={0}&longitude={1}&dateTime={2}&apiKey={3}"));
            }

            return null;
        }
    }
}
