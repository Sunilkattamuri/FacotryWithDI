using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherForecast.CrossCutting
{
    /// <summary>
    /// Class to implement the fetch api's
    /// </summary>
    public class FetchApiData : IFetchData
    {
        private string _url;


        public FetchApiData(string url)
        {
            _url = url;

        }

        /// <summary>
        /// Method to Fetch the data from API's
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<string> GetDataAsync(Dictionary<string, string> parameters)
        {

            return await FetchDataWithGet(parameters);

        }



        /// <summary>
        /// Function to get the Data from API
        /// </summary>
        /// <param name="parameters">Dictionary of input parameters</param>
        /// <returns></returns>
        private async Task<string> FetchDataWithGet(Dictionary<string, string> parameters)
        {
            try
            {
                SetUrl(parameters);
                using HttpClient httpClient = new HttpClient();
                using HttpResponseMessage response = await httpClient.GetAsync(_url);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }


        private void SetUrl(Dictionary<string, string> parameters)
        {
            _url = string.Format(_url, parameters["Latitude"], parameters["Longitude"], parameters["DateTime"], parameters["AppId"]);
        }


       
    }
}
