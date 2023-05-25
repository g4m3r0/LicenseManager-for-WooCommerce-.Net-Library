namespace LicenseManager.Lib.Models
{
    using System;
    using System.Text.Json.Serialization;
    using global::LicenseManager.Lib.Enums;
    using global::LicenseManager.Lib.JsonConverter;

    /// <summary>
    /// Represents a license object containing information about a specific license.
    /// </summary>
    public class UpdateLicense
    {
        /// <summary>
        /// Gets or sets the ID of the order associated with the license.
        /// </summary>
        [JsonPropertyName("order_id")]
        public int? OrderId { get; set; }

        /// <summary>
        /// Gets or sets the product identifier associated with the license.
        /// </summary>
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the license key associated with the license.
        /// </summary>
        [JsonPropertyName("license_key")]
        public string LicenseKey { get; set; }

        /// <summary>
        /// Gets or sets the expiration date of the license.
        /// </summary>
        [JsonPropertyName("expires_at")]
        [JsonConverter(typeof(CustomDateTimeJsonConverter))]
        public DateTime? ExpiresAt { get; set; }

        /// <summary>
        /// Gets or sets the status of the license (e.g. active, inactive).
        /// </summary>
        [JsonIgnore]
        public LicenseStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of times the license can be activated.
        /// </summary>
        [JsonPropertyName("times_activated_max")]
        public int TimesActivatedMax { get; set; }

        /// <summary>
        /// Gets or sets the user identifier associated with the license.
        /// </summary>
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets the status of the license in the API format (e.g. active, inactive).
        /// </summary>
        [JsonPropertyName("status")]
        public string RawStatus
        {
            get
            {
                return this.Status.ToString().ToLower();
            }

            private set
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
