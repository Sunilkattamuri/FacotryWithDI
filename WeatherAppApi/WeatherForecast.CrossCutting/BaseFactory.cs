using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Framework
{
    /// <summary>
    /// using factory pattern for creating objects
    /// </summary>
    public  class BaseFactory
    {
        private BaseFactory _factory;

        public BaseFactory()
        {

        }

        /// <summary>
        /// using dependency injection for injecting the factory
        /// </summary>
        /// <param name="baseFactory"></param>
        public BaseFactory(BaseFactory baseFactory)
        {
            _factory = baseFactory;
        }
      
        /// <summary>
        /// Getting the object based on the type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual object CreateNewInstance(Type type)
        {
            return _factory.CreateNewInstance(type);
        }
    }
}
