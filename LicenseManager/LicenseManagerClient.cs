namespace LicenseManagerClient.Lib
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using global::LicenseManagerClient.Lib.JsonConverter;
    using Models;
    using License = Models.License;

    public class LicenseManagerClient : IDisposable
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly string baseUrl;
        private readonly string consumerKey;
        private readonly string consumerSecret;

        private readonly JsonSerializerOptions jsonSerializerOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="LicenseManagerClient"/> class.
        /// </summary>
        /// <param name="baseUrl">Your wordpress host address (e.g. https://domain.com).</param>
        /// <param name="consumerKey">Your API consumer key.</param>
        /// <param name="consumerSecret">Your API consumer secret.</param>
        public LicenseManagerClient(string baseUrl, string consumerKey, string consumerSecret)
        {
            this.baseUrl = baseUrl;
            this.consumerKey = consumerKey;
            this.consumerSecret = consumerSecret;

            // Add a custom JSON converter to handle the date format returned by the API.
            this.jsonSerializerOptions = new JsonSerializerOptions();
            this.jsonSerializerOptions.Converters.Add(new CustomDateTimeJsonConverter());
        }

        /// <summary>
        /// Makes a GET request to the specified endpoint.
        /// </summary>
        private async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await this.httpClient.GetAsync($"{this.baseUrl}/wp-json/lmfwc/v2/{endpoint}?consumer_key={this.consumerKey}&consumer_secret={this.consumerSecret}");
            string responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<T>(responseBody, this.jsonSerializerOptions);
            }
            else
            {
                throw new Exception($"Error: {responseBody}");
            }
        }

        /// <summary>
        /// Makes a POST request to the specified endpoint.
        /// </summary>
        private async Task<T> PostAsync<T>(string endpoint, object data)
        {
            var content = new StringContent(JsonSerializer.Serialize(data, this.jsonSerializerOptions), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"{this.baseUrl}/wp-json/lmfwc/v2/{endpoint}?consumer_key={this.consumerKey}&consumer_secret={this.consumerSecret}", content);
            string responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<T>(responseBody, this.jsonSerializerOptions);
            }
            else
            {
                throw new Exception($"Error: {responseBody}");
            }
        }

        /// <summary>
        /// Makes a PUT request to the specified endpoint.
        /// </summary>
        private async Task<T> PutAsync<T>(string endpoint, object data)
        {
            var content = new StringContent(JsonSerializer.Serialize(data, this.jsonSerializerOptions), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PutAsync($"{this.baseUrl}/wp-json/lmfwc/v2/{endpoint}?consumer_key={this.consumerKey}&consumer_secret={consumerSecret}", content);
            string responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<T>(responseBody, this.jsonSerializerOptions);
            }
            else
            {
                throw new Exception($"Error: {responseBody}");
            }
        }

        public void Dispose()
        {
            this.httpClient.Dispose();
        }

        public async Task<LicenseResponse> ListLicenses()
        {
            var licenses = await this.GetAsync<LicenseResponse>("licenses");
            return licenses;
        }

        public async Task<LicenseKeyResponse> RetrieveLicense(string licenseKey)
        {
            var license = await this.GetAsync<LicenseKeyResponse>($"licenses/{licenseKey}");
            return license;
        }

        public async Task<LicenseKeyResponse> CreateLicense(CreateLicense license)
        {
            var createdLicense = await this.PostAsync<LicenseKeyResponse>("licenses", license);
            return createdLicense;
        }

        public async Task<LicenseKeyResponse> UpdateLicense(CreateLicense license, string licenseKey)
        {
            var updatedLicense = await this.PutAsync<LicenseKeyResponse>($"licenses/{licenseKey}", license);
            return updatedLicense;
        }

        public async Task<LicenseKeyResponse> ActivateLicense(string licenseKey)
        {
            var activation = await this.GetAsync<LicenseKeyResponse>($"licenses/activate/{licenseKey}");
            return activation;
        }

        public async Task<LicenseKeyResponse> ActivateLicense(License license) => await this.ActivateLicense(license.LicenseKey);

        public async Task<LicenseKeyResponse> DeactivateLicense(string licenseKey)
        {
            var deactivation = await this.GetAsync<LicenseKeyResponse>($"licenses/deactivate/{licenseKey}");
            return deactivation;
        }

        public async Task<LicenseKeyResponse> DeactivateLicense(License license) => await this.DeactivateLicense(license.LicenseKey);

        public async Task<LicenseValidationResponse> ValidateLicense(string licenseKey)
        {
            var validation = await this.GetAsync<LicenseValidationResponse>($"licenses/validate/{licenseKey}");
            return validation;
        }

        public async Task<LicenseValidationResponse> ValidateLicense(License license) => await this.ValidateLicense(license.LicenseKey);

        public async Task<GeneratorsResponse> ListGenerators()
        {
            var generators = await this.GetAsync<GeneratorsResponse>("generators");
            return generators;
        }

        public async Task<GeneratorResponse> RetrieveGenerator(int generatorId)
        {
            var generator = await this.GetAsync<GeneratorResponse>($"generators/{generatorId}");
            return generator;
        }

        public async Task<GeneratorResponse> CreateGenerator(Generator generator)
        {
            var createdGenerator = await this.PostAsync<GeneratorResponse>("generators", generator);
            return createdGenerator;
        }

        public async Task<GeneratorResponse> UpdateGenerator(Generator generator)
        {
            var updatedGenerator = await this.PutAsync<GeneratorResponse>($"generators/{generator.Id}", generator);
            return updatedGenerator;
        }

        public async Task<GeneratorGenerateResponse> GenerateGenerator(int generatorId)
        {
            var generatedKeys = await this.GetAsync<GeneratorGenerateResponse>($"generators/{generatorId}/generate");
            return generatedKeys;
        }

        public async Task<LicenseResponse> ValidateCustomerLicenses(int customerId)
        {
            var customerLicenses = await this.GetAsync<LicenseResponse>($"customers/{customerId}/licenses");
            return customerLicenses;
        }

        public async Task<PingResponse> ProductsPing(PingRequest pingRequest)
        {
            var pingResponse = await this.PostAsync<PingResponse>("products/ping", pingRequest);
            return pingResponse;
        }

        public async Task<ProductUpdateResponse> ProductsUpdate(string licenseKey)
        {
            var productUpdate = await this.GetAsync<ProductUpdateResponse>($"products/update/{licenseKey}");
            return productUpdate;
        }
    }
}
