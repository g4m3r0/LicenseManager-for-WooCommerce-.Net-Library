namespace LicenseManagerClient.Lib.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a response containing a list of generators.
    /// </summary>
    public class GeneratorsResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether the generator request was successful.
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the generator data.
        /// </summary>
        [JsonPropertyName("data")]
        public List<Generator> Data { get; set; }
    }
}
