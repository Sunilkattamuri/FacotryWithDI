using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Threading.Tasks;

namespace WeatherForecastUITest
{
    public class WeatherForecastTestCases
    {
        private WeatherForecastUI.Controllers.HomeController weatherForecast;

        [SetUp]
        public void Setup()
        {
            weatherForecast = new WeatherForecastUI.Controllers.HomeController(null, null);
        }

        [Test]
        public async Task PollutionDataTest()
        {
            var result = await weatherForecast.GetPollutionData(0.0, 10.0, System.DateTime.Now);
            Assert.IsInstanceOf(typeof(IActionResult), result);
        }
    }
}