namespace LicenseManager.Lib.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a response containing a product update.
    /// </summary>
    public class ProductUpdateResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether the product update request was successful.
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the product update data.
        /// </summary>
        [JsonPropertyName("data")]
        public ProductUpdate Data { get; set; }
    }
}