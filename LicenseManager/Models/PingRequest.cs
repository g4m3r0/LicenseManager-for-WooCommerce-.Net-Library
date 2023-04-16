namespace LicenseManagerClient.Lib.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a ping request.
    /// </summary>
    public class PingRequest
    {
        /// <summary>
        /// Gets or sets the license key to use for the ping request.
        /// </summary>
        [JsonPropertyName("license_key")]
        public string LicenseKey { get; set; }

        /// <summary>
        /// Gets or sets the name of the product to ping.
        /// </summary>
        [JsonPropertyName("product_name")]
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the host to ping.
        /// </summary>
        [JsonPropertyName("host")]
        public string Host { get; set; }
    }
}
