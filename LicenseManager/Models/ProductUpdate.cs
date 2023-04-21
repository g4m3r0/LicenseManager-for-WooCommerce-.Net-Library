namespace LicenseManager.Lib.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents product update data.
    /// </summary>
    public class ProductUpdate
    {
        /// <summary>
        /// Gets or sets the license key of the updated product.
        /// </summary>
        [JsonPropertyName("license_key")]
        public string LicenseKey { get; set; }

        /// <summary>
        /// Gets or sets the URL of the updated product.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the new version of the updated product.
        /// </summary>
        [JsonPropertyName("new_version")]
        public string NewVersion { get; set; }

        /// <summary>
        /// Gets or sets the package of the updated product.
        /// </summary>
        [JsonPropertyName("package")]
        public string Package { get; set; }

        /// <summary>
        /// Gets or sets the tested version of the updated product.
        /// </summary>
        [JsonPropertyName("tested")]
        public string Tested { get; set; }

        /// <summary>
        /// Gets or sets the required version of the updated product.
        /// </summary>
        [JsonPropertyName("requires")]
        public string Requires { get; set; }

        /// <summary>
        /// Gets or sets the required PHP version of the updated product.
        /// </summary>
        [JsonPropertyName("requires_php")]
        public string RequiresPhp { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the product was last updated.
        /// </summary>
        [JsonPropertyName("last_updated")]
        public object LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets the rating of the updated product.
        /// </summary>
        [JsonPropertyName("rating")]
        public object Rating { get; set; }

        /// <summary>
        /// Gets or sets the number of ratings of the updated product.
        /// </summary>
        [JsonPropertyName("num_ratings")]
        public int NumRatings { get; set; }

        /// <summary>
        /// Gets or sets the sections of the updated product.
        /// </summary>
        [JsonPropertyName("sections")]
        public ProductUpdateSections Sections { get; set; }
    }
}