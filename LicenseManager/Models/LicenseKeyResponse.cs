namespace LicenseManager.Lib.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a response containing a license key.
    /// </summary>
    public class LicenseKeyResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether the license key request was successful.
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the license key data.
        /// </summary>
        [JsonPropertyName("data")]
        public License Data { get; set; }
    }
}