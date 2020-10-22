using NUnit.Framework;
using System.Threading.Tasks;
using WeatherAppApi.Controllers;
using WeatherForecastModels;

namespace WeatherAppTest
{
    public class Tests
    {
        private WeatherForecastController weatherForecast;
        
        [SetUp]
        public void Setup()
        {
            weatherForecast = new WeatherForecastController(null, null);
        }

        [Test]
        public async Task GetPollutionData()
        {
            Response result = await weatherForecast.Get(0.0, 10.0, new System.DateTime().Date , "");

            Assert.AreEqual("401", result.Cod);
        }
    }
}