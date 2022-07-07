using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using LicenseManager.Enums;
using LicenseManager.Models;

namespace LicenseManager
{
    public class RequestHelper
    {
        private readonly string _host;
        private readonly string _consumerKey;
        private readonly string _consumerSecret;


        private static HttpClient _httpClient;

        /// <summary>
        /// Create new RequestHelper
        /// </summary>
        /// <param name="host">Your wordpress host address (e.g. https://domain.com).</param>
        /// <param name="consumerKey">Your API consumer key.</param>
        /// <param name="consumerSecret">Your API consumer secret.</param>
        public RequestHelper(string host, string consumerKey, string consumerSecret)
        {
            this._host = host;
            this._consumerKey = consumerKey;
            this._consumerSecret = consumerSecret;

            _httpClient = new HttpClient();

            //todo: set base address to host
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); //only json data
        }

        public async Task<(string, string)> GetLicenseJsonAsync(string licenseKey, RequestTypeEnum requestType)
        {
            var requestUrl = requestType == 0
                ? GetActivateLicenseRequestUrl(licenseKey)
                : GetValidateLicenseRequestUrl(licenseKey);

            string error = null;
            string jsonString = "";

            try
            {
                var response = await _httpClient.GetAsync(requestUrl);

                if (!response.IsSuccessStatusCode)
                    throw new Exception("Http status code not successful or reached max activation count.");

                jsonString = await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                error = e.Message;
            }

            return (jsonString, error);
        }

        private string GetActivateLicenseRequestUrl(string licenseKey)
        {
            return $"{this._host}/wp-json/lmfwc/v2/licenses/activate/{licenseKey}?consumer_key={this._consumerKey}&consumer_secret={this._consumerSecret}";
        }
        private string GetValidateLicenseRequestUrl(string licenseKey)
        {
            return $"{this._host}/wp-json/lmfwc/v2/licenses/{licenseKey}?consumer_key={this._consumerKey}&consumer_secret={this._consumerSecret}";
        }
    }
}
