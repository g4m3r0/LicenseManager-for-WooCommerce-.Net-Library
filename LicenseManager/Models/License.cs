namespace LicenseManagerClient.Lib.Models
{
    using System;
    using System.Text.Json.Serialization;
    using global::LicenseManagerClient.Lib.Enums;
    using global::LicenseManagerClient.Lib.JsonConverter;

    /// <summary>
    /// Represents a license for a product.
    /// </summary>
    public class License
    {
        /// <summary>
        /// Gets or sets the ID of the license.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the order associated with the license.
        /// </summary>
        [JsonPropertyName("orderId")]
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the product associated with the license.
        /// </summary>
        [JsonPropertyName("productId")]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user associated with the license.
        /// </summary>
        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the license key.
        /// </summary>
        [JsonPropertyName("licenseKey")]
        public string LicenseKey { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the license expires.
        /// </summary>
        [JsonPropertyName("expiresAt")]
        [JsonConverter(typeof(CustomDateTimeJsonConverter))]
        public DateTime? ExpiresAt { get; set; }

        /// <summary>
        /// Gets or sets the number of days the license is valid for.
        /// </summary>
        [JsonPropertyName("validFor")]
        public int ValidFor { get; set; }

        /// <summary>
        /// Gets or sets the source of the license.
        /// </summary>
        [JsonPropertyName("source")]
        public int Source { get; set; }

        /// <summary>
        /// Gets or sets the status of the license.
        /// </summary>
        public LicenseStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the number of times the license has been activated.
        /// </summary>
        [JsonPropertyName("timesActivated")]
        public int? TimesActivated { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of times the license can be activated.
        /// </summary>
        [JsonPropertyName("timesActivatedMax")]
        public int TimesActivatedMax { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the license was created.
        /// </summary>
        [JsonPropertyName("createdAt")]
        [JsonConverter(typeof(CustomDateTimeJsonConverter))]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who created the license.
        /// </summary>
        [JsonPropertyName("createdBy")]
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the license was last updated.
        /// </summary>
        [JsonPropertyName("updatedAt")]
        [JsonConverter(typeof(CustomDateTimeJsonConverter))]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who last updated the license.
        /// </summary>
        [JsonPropertyName("updatedBy")]
        public int UpdatedBy { get; set; }

        [JsonPropertyName("status")]
        private string RawStatus
        {
            get
            {
                return this.Status.ToString();
            }

            set
            {
                if (this.RawStatus != value)
                {
                    this.RawStatus = value;
                }

                Enum.TryParse<LicenseStatus>(value, out var temp);
                this.Status = temp;
            }
        }
    }
}