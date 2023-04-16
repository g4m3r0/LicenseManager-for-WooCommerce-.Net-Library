namespace LicenseManagerClient.Lib.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the product SKU.
        /// </summary>
        [JsonPropertyName("sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        [JsonPropertyName("price")]
        public string Price { get; set; }

        /// <summary>
        /// Gets or sets the product sale price.
        /// </summary>
        [JsonPropertyName("salePrice")]
        public string SalePrice { get; set; }

        /// <summary>
        /// Gets or sets the product description.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the product short description.
        /// </summary>
        [JsonPropertyName("shortDescription")]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the product availability information.
        /// </summary>
        [JsonPropertyName("availability")]
        public Availability Availability { get; set; }
    }
}
