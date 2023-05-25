namespace LicenseManager.Lib.Models
{
    using System;
    using System.Text.Json.Serialization;
    using global::LicenseManager.Lib.Enums;

    /// <summary>
    /// Represents a request to generate licenses using a specific generator configuration.
    /// </summary>
    public class GeneratorGenerate
    {
        /// <summary>
        /// Gets or sets the number of licenses to generate.
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the generated licenses should be saved.
        /// </summary>
        [JsonPropertyName("save")]
        public bool Save { get; set; }

        /// <summary>
        /// Gets or sets the status of the licenses to generate (e.g., active, inactive).
        /// </summary>
        public LicenseStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the order identifier associated with the generated licenses, if applicable.
        /// </summary>
        [JsonPropertyName("order_id")]
        public int? OrderId { get; set; }

        /// <summary>
        /// Gets or sets the product identifier associated with the generated licenses.
        /// </summary>
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier associated with the generated licenses.
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
