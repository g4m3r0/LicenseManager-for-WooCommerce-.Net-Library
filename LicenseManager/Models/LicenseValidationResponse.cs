namespace LicenseManagerClient.Lib.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a response containing license validation data.
    /// </summary>
    public class LicenseValidationResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether the license validation request was successful.
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the license validation data.
        /// </summary>
        [JsonPropertyName("data")]
        public LicenseValidationData Data { get; set; }
    }
}