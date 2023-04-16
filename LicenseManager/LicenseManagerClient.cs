namespace LicenseManagerClient.Lib
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using global::LicenseManagerClient.Lib.JsonConverter;
    using Models;
    using License = Models.License;

    /// <summary>
    /// Represents a client for communicating with a License Manager API.
    /// </summary>
    public class LicenseManagerClient : IDisposable
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly string baseUrl;
        private readonly string consumerKey;
        private readonly string consumerSecret;

        private readonly JsonSerializerOptions jsonSerializerOptions;

        // Flag to indicate if the object has already been disposed.
        private bool disposed = false;

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
        /// Finalizes an instance of the <see cref="LicenseManagerClient"/> class.
        /// </summary>
        ~LicenseManagerClient()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Lists all licenses.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, containing the list of licenses.</returns>
        public async Task<LicenseResponse> ListLicenses()
        {
            var licenses = await this.GetAsync<LicenseResponse>("licenses");
            return licenses;
        }

        /// <summary>
        /// Retrieves a specific license by its key.
        /// </summary>
        /// <param name="licenseKey">The license key to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation, containing the license information.</returns>
        public async Task<LicenseKeyResponse> RetrieveLicense(string licenseKey)
        {
            var license = await this.GetAsync<LicenseKeyResponse>($"licenses/{licenseKey}");
            return license;
        }

        /// <summary>
        /// Creates a new license.
        /// </summary>
        /// <param name="license">The license information to create.</param>
        /// <returns>A task that represents the asynchronous operation, containing the created license information.</returns>
        public async Task<LicenseKeyResponse> CreateLicense(CreateLicense license)
        {
            var createdLicense = await this.PostAsync<LicenseKeyResponse>("licenses", license);
            return createdLicense;
        }

        /// <summary>
        /// Updates an existing license.
        /// </summary>
        /// <param name="license">The license information to update.</param>
        /// <param name="licenseKey">The license key to update.</param>
        /// <returns>A task that represents the asynchronous operation, containing the updated license information.</returns>
        public async Task<LicenseKeyResponse> UpdateLicense(CreateLicense license, string licenseKey)
        {
            var updatedLicense = await this.PutAsync<LicenseKeyResponse>($"licenses/{licenseKey}", license);
            return updatedLicense;
        }

        /// <summary>
        /// Activates a license by its key.
        /// </summary>
        /// <param name="licenseKey">The license key to activate.</param>
        /// <returns>A task that represents the asynchronous operation, containing the activation status.</returns>
        public async Task<LicenseKeyResponse> ActivateLicense(string licenseKey)
        {
            var activation = await this.GetAsync<LicenseKeyResponse>($"licenses/activate/{licenseKey}");
            return activation;
        }

        /// <summary>
        /// Activates a license.
        /// </summary>
        /// <param name="license">The license to activate.</param>
        /// <returns>A task that represents the asynchronous operation, containing the activation status.</returns>
        public async Task<LicenseKeyResponse> ActivateLicense(License license) => await this.ActivateLicense(license.LicenseKey);

        /// <summary>
        /// Deactivates a license by its key.
        /// </summary>
        /// <param name="licenseKey">The license key to deactivate.</param>
        /// <returns>A task that represents the asynchronous operation, containing the deactivation status.</returns>
        public async Task<LicenseKeyResponse> DeactivateLicense(string licenseKey)
        {
            var deactivation = await this.GetAsync<LicenseKeyResponse>($"licenses/deactivate/{licenseKey}");
            return deactivation;
        }

        /// <summary>
        /// Deactivates a license.
        /// </summary>
        /// <param name="license">The license to deactivate.</param>
        /// <returns>A task that represents the asynchronous operation, containing the deactivation status.</returns>
        public async Task<LicenseKeyResponse> DeactivateLicense(License license) => await this.DeactivateLicense(license.LicenseKey);

        /// <summary>
        /// Validates a license by its key.
        /// </summary>
        /// <param name="licenseKey">The license key to validate.</param>
        /// <returns>A task that represents the asynchronous operation, containing the validation response.</returns>
        public async Task<LicenseValidationResponse> ValidateLicense(string licenseKey)
        {
            var validation = await this.GetAsync<LicenseValidationResponse>($"licenses/validate/{licenseKey}");
            return validation;
        }

        /// <summary>
        /// Validates a license.
        /// </summary>
        /// <param name="license">The license to validate.</param>
        /// <returns>A task that represents the asynchronous operation, containing the validation response.</returns>
        public async Task<LicenseValidationResponse> ValidateLicense(License license) => await this.ValidateLicense(license.LicenseKey);

        /// <summary>
        /// Lists all generators.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, containing the list of generators.</returns>
        public async Task<GeneratorsResponse> ListGenerators()
        {
            var generators = await this.GetAsync<GeneratorsResponse>("generators");
            return generators;
        }

        /// <summary>
        /// Retrieves a specific generator by its ID.
        /// </summary>
        /// <param name="generatorId">The generator ID to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation, containing the generator information.</returns>
        public async Task<GeneratorResponse> RetrieveGenerator(int generatorId)
        {
            var generator = await this.GetAsync<GeneratorResponse>($"generators/{generatorId}");
            return generator;
        }

        /// <summary>
        /// Creates a new generator.
        /// </summary>
        /// <param name="generator">The generator information to create.</param>
        /// <returns>A task that represents the asynchronous operation, containing the created generator information.</returns>
        public async Task<GeneratorResponse> CreateGenerator(CreateGenerator generator)
        {
            var createdGenerator = await this.PostAsync<GeneratorResponse>("generators", generator);
            return createdGenerator;
        }

        /// <summary>
        /// Updates an existing generator.
        /// </summary>
        /// <param name="generator">The generator information to update.</param>
        /// <param name="generatorId">The generator ID to update.</param>
        /// <returns>A task that represents the asynchronous operation, containing the updated generator information.</returns>
        public async Task<GeneratorResponse> UpdateGenerator(CreateGenerator generator, int generatorId)
        {
            var updatedGenerator = await this.PutAsync<GeneratorResponse>($"generators/{generatorId}", generator);
            return updatedGenerator;
        }

        /// <summary>
        /// Generates keys for a generator.
        /// </summary>
        /// <param name="generate">The generation information.</param>
        /// <param name="generatorId">The generator ID to generate keys for.</param>
        /// <returns>A task that represents the asynchronous operation, containing the generated keys.</returns>
        public async Task<GeneratorGenerateResponse> GenerateGenerator(GeneratorGenerate generate, int generatorId)
        {
            var generatedKeys = await this.PostAsync<GeneratorGenerateResponse>($"generators/{generatorId}/generate", generate);
            return generatedKeys;
        }

        /// <summary>
        /// Validates customer licenses.
        /// </summary>
        /// <param name="customerId">The customer ID to validate licenses for.</param>
        /// <returns>A task that represents the asynchronous operation, containing the list of customer licenses.</returns>
        public async Task<LicenseResponse> ValidateCustomerLicenses(int customerId)
        {
            var customerLicenses = await this.GetAsync<LicenseResponse>($"customers/{customerId}/licenses");
            return customerLicenses;
        }

        /// <summary>
        /// Pings the products.
        /// </summary>
        /// <param name="pingRequest">The ping request information.</param>
        /// <returns>A task that represents the asynchronous operation, containing the ping response.</returns>
        public async Task<PingResponse> ProductsPing(PingRequest pingRequest)
        {
            var pingResponse = await this.PostAsync<PingResponse>("products/ping", pingRequest);
            return pingResponse;
        }

        /// <summary>
        /// Updates a product.
        /// </summary>
        /// <param name="licenseKey">The license key associated with the product to update.</param>
        /// <returns>A task that represents the asynchronous operation, containing the product update response.</returns>
        public async Task<ProductUpdateResponse> ProductsUpdate(string licenseKey)
        {
            var productUpdate = await this.GetAsync<ProductUpdateResponse>($"products/update/{licenseKey}");
            return productUpdate;
        }

        /// <summary>
        /// Releases unmanaged resources used by the LicenseManagerClient.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and optionally managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources here
                    this.httpClient.Dispose();
                }

                // Dispose unmanaged resources here, if any.
                this.disposed = true;
            }
        }

        /// <summary>
        /// Makes a GET request to the specified endpoint.
        /// </summary>
        /// <typeparam name="T">The type of the expected response.</typeparam>
        /// <param name="endpoint">The API endpoint to send the request to.</param>
        /// <returns>A task that represents the asynchronous operation, containing the deserialized response.</returns>
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
                throw new WebException($"Error: {responseBody}");
            }
        }

        /// <summary>
        /// Makes a POST request to the specified endpoint.
        /// </summary>
        /// <typeparam name="T">The type of the expected response.</typeparam>
        /// <param name="endpoint">The API endpoint to send the request to.</param>
        /// <param name="data">The data to send as the request body.</param>
        /// <returns>A task that represents the asynchronous operation, containing the deserialized response.</returns>
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
                throw new WebException($"Error: {responseBody}");
            }
        }

        /// <summary>
        /// Makes a PUT request to the specified endpoint.
        /// </summary>
        /// <typeparam name="T">The type of the expected response.</typeparam>
        /// <param name="endpoint">The API endpoint to send the request to.</param>
        /// <param name="data">The data to send as the request body.</param>
        /// <returns>A task that represents the asynchronous operation, containing the deserialized response.</returns>
        private async Task<T> PutAsync<T>(string endpoint, object data)
        {
            var content = new StringContent(JsonSerializer.Serialize(data, this.jsonSerializerOptions), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PutAsync($"{this.baseUrl}/wp-json/lmfwc/v2/{endpoint}?consumer_key={this.consumerKey}&consumer_secret={this.consumerSecret}", content);
            string responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<T>(responseBody, this.jsonSerializerOptions);
            }
            else
            {
                throw new WebException($"Error: {responseBody}");
            }
        }
    }
}
