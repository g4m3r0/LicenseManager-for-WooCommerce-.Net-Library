namespace LicenseManagerClient.Lib.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a response containing a list of licenses.
    /// </summary>
    public class LicenseResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether the license request was successful.
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; } = false;

        /// <summary>
        /// Gets or sets the license data.
        /// </summary>
        [JsonPropertyName("data")]
        public List<License> Data { get; set; }
    }
}