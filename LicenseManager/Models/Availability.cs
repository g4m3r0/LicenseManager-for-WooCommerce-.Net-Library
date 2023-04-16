namespace LicenseManagerClient.Lib.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents the availability information of a product.
    /// </summary>
    public class Availability
    {
        /// <summary>
        /// Gets or sets the availability status of the product.
        /// </summary>
        [JsonPropertyName("availability")]
        public string AvailabilityStatus { get; set; }

        /// <summary>
        /// Gets or sets the class to apply to the availability status element.
        /// </summary>
        [JsonPropertyName("class")]
        public string Class { get; set; }
    }
}