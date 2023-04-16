namespace LicenseManagerClient.Lib.Models
{
    using System;
    using System.Text.Json.Serialization;
    using global::LicenseManagerClient.Lib.Enums;
    using JsonConverter;

    /// <summary>
    /// Represents a license object containing information about a specific license.
    /// </summary>
    public class CreateLicense
    {
        /// <summary>
        /// Gets or sets the ID of the order associated with the license.
        /// </summary>
        [JsonPropertyName("orderId")]
        public int OrderId { get; set; }

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
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        /// Gets or sets the status of the license (e.g., active, inactive).
        /// </summary>

        public LicenseStatus Status { get; set; }

        [JsonPropertyName("status")]
        private string RawStatus
        {
            get
            {
                return this.Status.ToString();
            }

            set
            {
                if (this.RawStatus == value)
                {
                    return;
                }

                this.RawStatus = value;
                Enum.TryParse<LicenseStatus>(value, out var temp);
                this.Status = temp;
            }
        }

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
    }
}
