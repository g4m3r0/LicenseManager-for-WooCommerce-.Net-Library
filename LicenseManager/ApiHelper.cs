using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using LicenseManager.Models;
using Newtonsoft.Json;

namespace LicenseManager
{
    public class ApiHelper
    {
        private readonly string _host;
        private readonly string _consumerKey;
        private readonly string _consumerSecret;
        private readonly bool _verifyHardwareId;
        private static HttpClient _httpClient;


        /// <summary>
        /// Create a new license manager
        /// </summary>
        /// <param name="host">Your wordpress host address (e.g. https://domain.com).</param>
        /// <param name="consumerKey">Your API consumer key.</param>
        /// <param name="consumerSecret">Your API consumer secret.</param>
        /// <param name="verifyHardwareId">Choose if the hardware id should be verified.</param>
        public ApiHelper(string host, string consumerKey, string consumerSecret, bool verifyHardwareId)
        {
            this._host = host;
            this._consumerKey = consumerKey;
            this._consumerSecret = consumerSecret;
            this._verifyHardwareId = verifyHardwareId;

            _httpClient = new HttpClient();
            //todo: set base address to host
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); //only json data
        }

        /// <summary>
        /// Activate license key.
        /// </summary>
        /// <param name="licenseKey">product license key</param>
        /// <param name="productId">product id</param>
        /// <returns>True if license was activated.</returns>
        public bool ActivateLicense(string licenseKey, string productId)
        {
            return Task.Run(() => AsyncActivateLicense(licenseKey, productId)).Result;
        }

        /// <summary>
        /// Activate license key.
        /// </summary>
        /// <param name="licenseKey"></param>
        /// <param name="productId"></param>
        /// <returns>True if license was activated.</returns>
        private async Task<bool> AsyncActivateLicense(string licenseKey, string productId)
        {
            var requestUrl = $"{this._host}/wp-json/lmfwc/v2/licenses/activate/{licenseKey}?consumer_key={this._consumerKey}&consumer_secret={this._consumerSecret}";
            using (var response = await _httpClient.GetAsync(requestUrl))
            {
                if (response.IsSuccessStatusCode) {
                    var license = await response.Content.ReadAsAsync<LicenseModel>();

                    if (license.Data.TimesActivatedMax <= license.Data.TimesActivated)
                        return false;

                    return license.Data.ProductId == productId; //todo: test if activated for this computers hardware id
                } else { 
                    return false; 
                    //throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /// <summary>
        /// Validate license key.
        /// </summary>
        /// <param name="licenseKey"></param>
        /// <param name="productId"></param>
        /// <returns>True if license was validated.</returns>
        public bool ValidateLicense(string licenseKey, string productId)
        {
            return Task.Run(() => AsyncValidateLicense(licenseKey, productId)).Result; //todo possible deadlock
        }

        /// <summary>
        /// Validate license key.
        /// </summary>
        /// <param name="licenseKey"></param>
        /// <param name="productId"></param>
        /// <returns>True if license was validated.</returns>
        public async Task<bool> AsyncValidateLicense(string licenseKey, string productId)
        {
            var requestUrl = $"{this._host}/wp-json/lmfwc/v2/licenses/validate/{licenseKey}?consumer_key={this._consumerKey}&consumer_secret={this._consumerSecret}";
            using (var response = await _httpClient.GetAsync(requestUrl))
            { 
                if (response.IsSuccessStatusCode)
                {
                    var license = await response.Content.ReadAsAsync<LicenseModel>();
                    return license.Success;
                } else { 
                    return false; 
                    //throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
