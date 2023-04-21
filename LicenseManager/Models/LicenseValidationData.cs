namespace LicenseManager.Lib.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents the data returned by the license validation API endpoint.
    /// </summary>
    public class LicenseValidationData
    {
        /// <summary>
        /// Gets or sets the number of times the license has been activated.
        /// </summary>
        [JsonPropertyName("timesActivated")]
        public int? TimesActivated { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of times the license can be activated.
        /// </summary>
        [JsonPropertyName("timesActivatedMax")]
        public int? TimesActivatedMax { get; set; }

        /// <summary>
        /// Gets or sets the number of remaining activations for the license.
        /// </summary>
        [JsonPropertyName("remainingActivations")]
        public int? RemainingActivations { get; set; }

        /// <summary>
        /// Gets or sets the product associated with the license.
        /// </summary>
        [JsonPropertyName("product")]
        public Product Product { get; set; }
    }
}