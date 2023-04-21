namespace LicenseManager.Lib
{
    using System;
    using System.Globalization;
    using System.Net;
    using System.Net.Http;
    using System.Resources;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using LicenseManager.Lib.JsonConverter;
    using LicenseManager.Lib.Models;
    using License = LicenseManager.Lib.Models.License;

    /// <summary>
    /// Represents a client for communicating with a License Manager API.
    /// </summary>
    public class LicenseManagerClient : IDisposable
    {
        // TODO add configure await false to all async calls
        private static readonly ResourceManager ResourceManager = new ResourceManager("LicenseManagerClient.Lib.Messages.Messages", typeof(LicenseManagerClient).Assembly);

        private readonly HttpClient httpClient = new HttpClient();
        private readonly string baseUrl;
        private readonly string consumerKey;
        private readonly string consumerSecret;
        private readonly int productId;

        private readonly JsonSerializerOptions jsonSerializerOptions;

        private readonly CultureInfo cultureInfo;

        // Flag to indicate if the object has already been disposed.
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="LicenseManagerClient"/> class.
        /// </summary>
        /// <param name="baseUrl">Your wordpress host address (e.g. https://domain.com).</param>
        /// <param name="consumerKey">Your API consumer key.</param>
        /// <param name="consumerSecret">Your API consumer secret.</param>
        /// <param name="productId">The product ID to use for API calls.</param>
        /// <param name="messageLanguage">The language to use for error messages.</param>
        public LicenseManagerClient(string baseUrl, string consumerKey, string consumerSecret, int productId, CultureInfo messageLanguage)
        {
            this.baseUrl = baseUrl;
            this.consumerKey = consumerKey;
            this.consumerSecret = consumerSecret;
            this.productId = productId;
            this.cultureInfo = messageLanguage;

            // Add a custom JSON converter to handle the date format returned by the API.
            this.jsonSerializerOptions = new JsonSerializerOptions();
            this.jsonSerializerOptions.Converters.Add(new CustomDateTimeJsonConverter());
        }

        /// <summary>
        /// Lists all licenses.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, containing the list of licenses.</returns>
        public async Task<LicenseResponse> ListLicensesAsync()
        {
            var licenses = await this.GetAsync<LicenseResponse>("licenses");
            return licenses;
        }

        /// <summary>
        /// Retrieves a specific license by its key.
        /// </summary>
        /// <param name="licenseKey">The license key to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation, containing the license information.</returns>
        public async Task<LicenseKeyResponse> RetrieveLicenseAsync(string licenseKey)
        {
            var license = await this.GetAsync<LicenseKeyResponse>($"licenses/{licenseKey}");
            return license;
        }

        /// <summary>
        /// Creates a new license.
        /// </summary>
        /// <param name="license">The license information to create.</param>
        /// <returns>A task that represents the asynchronous operation, containing the created license information.</returns>
        public async Task<LicenseKeyResponse> CreateLicenseAsync(CreateLicense license)
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
        public async Task<LicenseKeyResponse> UpdateLicenseAsync(CreateLicense license, string licenseKey)
        {
            var updatedLicense = await this.PutAsync<LicenseKeyResponse>($"licenses/{licenseKey}", license);
            return updatedLicense;
        }

        /// <summary>
        /// Activates a license by its key.
        /// </summary>
        /// <param name="licenseKey">The license key to activate.</param>
        /// <returns>A task that represents the asynchronous operation, containing the activation status.</returns>
        public async Task<LicenseKeyResponse> ActivateLicenseAsync(string licenseKey)
        {
            var activation = await this.GetAsync<LicenseKeyResponse>($"licenses/activate/{licenseKey}");
            return activation;
        }

        /// <summary>
        /// Activates a license.
        /// </summary>
        /// <param name="license">The license to activate.</param>
        /// <returns>A task that represents the asynchronous operation, containing the activation status.</returns>
        public async Task<LicenseKeyResponse> ActivateLicenseAsync(License license) => await this.ActivateLicenseAsync(license.LicenseKey);

        /// <summary>
        /// Deactivates a license by its key.
        /// </summary>
        /// <param name="licenseKey">The license key to deactivate.</param>
        /// <returns>A task that represents the asynchronous operation, containing the deactivation status.</returns>
        public async Task<LicenseKeyResponse> DeactivateLicenseAsync(string licenseKey)
        {
            var deactivation = await this.GetAsync<LicenseKeyResponse>($"licenses/deactivate/{licenseKey}");
            return deactivation;
        }

        /// <summary>
        /// Deactivates a license.
        /// </summary>
        /// <param name="license">The license to deactivate.</param>
        /// <returns>A task that represents the asynchronous operation, containing the deactivation status.</returns>
        public async Task<LicenseKeyResponse> DeactivateLicenseAsync(License license) => await this.DeactivateLicenseAsync(license.LicenseKey);

        /// <summary>
        /// Validates a license by its key.
        /// </summary>
        /// <param name="licenseKey">The license key to validate.</param>
        /// <returns>A task that represents the asynchronous operation, containing the validation response.</returns>
        public async Task<LicenseValidationResponse> ValidateLicenseAsync(string licenseKey)
        {
            var validation = await this.GetAsync<LicenseValidationResponse>($"licenses/validate/{licenseKey}");
            return validation;
        }

        /// <summary>
        /// Validates a license.
        /// </summary>
        /// <param name="license">The license to validate.</param>
        /// <returns>A task that represents the asynchronous operation, containing the validation response.</returns>
        public async Task<LicenseValidationResponse> ValidateLicenseAsync(License license) => await this.ValidateLicenseAsync(license.LicenseKey);

        /// <summary>
        /// Lists all generators.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, containing the list of generators.</returns>
        public async Task<GeneratorsResponse> ListGeneratorsAsync()
        {
            var generators = await this.GetAsync<GeneratorsResponse>("generators");
            return generators;
        }

        /// <summary>
        /// Retrieves a specific generator by its ID.
        /// </summary>
        /// <param name="generatorId">The generator ID to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation, containing the generator information.</returns>
        public async Task<GeneratorResponse> RetrieveGeneratorAsync(int generatorId)
        {
            var generator = await this.GetAsync<GeneratorResponse>($"generators/{generatorId}");
            return generator;
        }

        /// <summary>
        /// Creates a new generator.
        /// </summary>
        /// <param name="generator">The generator information to create.</param>
        /// <returns>A task that represents the asynchronous operation, containing the created generator information.</returns>
        public async Task<GeneratorResponse> CreateGeneratorAsync(CreateGenerator generator)
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
        public async Task<GeneratorResponse> UpdateGeneratorAsync(CreateGenerator generator, int generatorId)
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
        public async Task<GeneratorGenerateResponse> GenerateGeneratorAsync(GeneratorGenerate generate, int generatorId)
        {
            var generatedKeys = await this.PostAsync<GeneratorGenerateResponse>($"generators/{generatorId}/generate", generate);
            return generatedKeys;
        }

        /// <summary>
        /// Validates customer licenses.
        /// </summary>
        /// <param name="customerId">The customer ID to validate licenses for.</param>
        /// <returns>A task that represents the asynchronous operation, containing the list of customer licenses.</returns>
        public async Task<LicenseResponse> ValidateCustomerLicensesAsync(int customerId)
        {
            var customerLicenses = await this.GetAsync<LicenseResponse>($"customers/{customerId}/licenses");
            return customerLicenses;
        }

        /// <summary>
        /// Pings the products.
        /// </summary>
        /// <param name="pingRequest">The ping request information.</param>
        /// <returns>A task that represents the asynchronous operation, containing the ping response.</returns>
        public async Task<PingResponse> ProductsPingAsync(PingRequest pingRequest)
        {
            var pingResponse = await this.PostAsync<PingResponse>("products/ping", pingRequest);
            return pingResponse;
        }

        /// <summary>
        /// Updates a product.
        /// </summary>
        /// <param name="licenseKey">The license key associated with the product to update.</param>
        /// <returns>A task that represents the asynchronous operation, containing the product update response.</returns>
        public async Task<ProductUpdateResponse> ProductsUpdateAsync(string licenseKey)
        {
            var productUpdate = await this.GetAsync<ProductUpdateResponse>($"products/update/{licenseKey}");
            return productUpdate;
        }

        /// <summary>
        /// Checks the license activation response and returns a CheckLicenseResponse based on the validation.
        /// </summary>
        /// <param name="licenseKeyResponse">The LicenseKeyResponse object containing the activation response.</param>
        /// <param name="licenseKey">The license key that was used for activation.</param>
        /// <returns>A CheckLicenseResponse object indicating the success or failure of the activation check.</returns>
        public LicenseCheckResponse CheckLicenseActivation(LicenseKeyResponse licenseKeyResponse, string licenseKey)
        {
            if (licenseKeyResponse == null)
            {
                return this.GenerateCheckLicenseResponse(false, "LicenseResponseNull");
            }

            if (!licenseKeyResponse.Success)
            {
                return this.GenerateCheckLicenseResponse(false, "LicenseActivationFailed");
            }

            if (licenseKeyResponse.Data.LicenseKey != licenseKey)
            {
                return this.GenerateCheckLicenseResponse(false, "LicenseKeyNotMatching");
            }

            if (licenseKeyResponse.Data.ProductId != this.productId)
            {
                return this.GenerateCheckLicenseResponse(false, "ProductIdNotMatching");
            }

            if (licenseKeyResponse.Data.TimesActivated > licenseKeyResponse.Data.TimesActivatedMax)
            {
                return this.GenerateCheckLicenseResponse(false, "MaxActivationsReached");
            }

            return this.GenerateCheckLicenseResponse(true, "LicenseActivationSuccess");
        }

        /// <summary>
        /// Checks the license validation response and returns a CheckLicenseResponse based on the validation.
        /// </summary>
        /// <param name="licenseValidationResponse">The LicenseValidationResponse object containing the validation response.</param>
        /// <param name="licenseKey">The license key that was used for validation.</param>
        /// <returns>A CheckLicenseResponse object indicating the success or failure of the validation check.</returns>
        public LicenseCheckResponse CheckLicenseValidation(LicenseValidationResponse licenseValidationResponse, string licenseKey)
        {
            if (licenseValidationResponse == null)
            {
                return this.GenerateCheckLicenseResponse(false, "LicenseResponseNull");
            }

            if (!licenseValidationResponse.Success)
            {
                return this.GenerateCheckLicenseResponse(false, "LicenseValidationFailed");
            }

            // TODO Product is always null in the response.
            if (licenseValidationResponse.Data.Product != null && licenseValidationResponse.Data.Product.Id != this.productId)
            {
                return this.GenerateCheckLicenseResponse(false, "ProductIdNotMatching");
            }

            if (licenseValidationResponse.Data.TimesActivated == null || licenseValidationResponse.Data.TimesActivated == 0)
            {
                return this.GenerateCheckLicenseResponse(false, "LicenseNotActivated");
            }

            if (licenseValidationResponse.Data.TimesActivated > licenseValidationResponse.Data.TimesActivatedMax)
            {
                return this.GenerateCheckLicenseResponse(false, "MaxActivationsReached");
            }

            return this.GenerateCheckLicenseResponse(true, "LicenseValidationSuccess");
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
        /// Generates a LicenseCheckResponse object based on the given success status and the resource name for the message.
        /// </summary>
        /// <param name="success">A boolean value indicating whether the operation was successful.</param>
        /// <param name="resourceName">The name of the resource string to be used as the message in the response.</param>
        /// <returns>A LicenseCheckResponse object with the specified success status and message.</returns>
        private LicenseCheckResponse GenerateCheckLicenseResponse(bool success, string resourceName)
        {
            string message = ResourceManager.GetString(resourceName, this.cultureInfo);
            return new LicenseCheckResponse()
            {
                Success = success,
                Message = message,
            };
        }

        /// <summary>
        /// Makes a GET request to the specified endpoint.
        /// </summary>
        /// <typeparam name="T">The type of the expected response.</typeparam>
        /// <param name="endpoint">The API endpoint to send the request to.</param>
        /// <returns>A task that represents the asynchronous operation, containing the deserialized response.</returns>
        private async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await this.httpClient.GetAsync($"{this.baseUrl}/wp-json/lmfwc/v2/{endpoint}?consumer_key={this.consumerKey}&consumer_secret={this.consumerSecret}").ConfigureAwait(false);
            string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

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
            var response = await this.httpClient.PostAsync($"{this.baseUrl}/wp-json/lmfwc/v2/{endpoint}?consumer_key={this.consumerKey}&consumer_secret={this.consumerSecret}", content).ConfigureAwait(false);
            string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

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
            var response = await this.httpClient.PutAsync($"{this.baseUrl}/wp-json/lmfwc/v2/{endpoint}?consumer_key={this.consumerKey}&consumer_secret={this.consumerSecret}", content).ConfigureAwait(false);
            string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

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
