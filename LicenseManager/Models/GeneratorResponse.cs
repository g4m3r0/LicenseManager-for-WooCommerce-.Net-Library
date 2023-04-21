namespace LicenseManager.Lib.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a response containing a generator.
    /// </summary>
    public class GeneratorResponse
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
        public Generator Data { get; set; }
    }
}
