using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecast.DAL;
using WeatherForecast.Framework;

namespace WeatherAppBL
{
    public class BLFactory : BaseFactory
    {
        public BLFactory() 
        {

        }
        protected BLFactory(BaseFactory baseFactory) : base(baseFactory)
        {

        }

        public override object CreateNewInstance(Type type)
        {
            if(Type.Equals(type,typeof(PollutionDataBL)))
            {
                return new PollutionDataBL((PollutionDataDAL) new BaseFactory(new DALFactory())
                    .CreateNewInstance(typeof(PollutionDataDAL)));
            }

            return null;

        }
    }
}
