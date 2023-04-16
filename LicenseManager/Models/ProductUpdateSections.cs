namespace LicenseManagerClient.Lib.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents product update sections.
    /// </summary>
    public class ProductUpdateSections
    {
        /// <summary>
        /// Gets or sets the changelog section of the updated product.
        /// </summary>
        [JsonPropertyName("changelog")]
        public string Changelog { get; set; }
    }
}