namespace LicenseManagerClient.Lib.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a response containing a list of generated items by a generator.
    /// </summary>
    public class GeneratorGenerateResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether the generator generation request was successful.
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the list of generated items.
        /// </summary>
        [JsonPropertyName("data")]
        public List<string> Data { get; set; }
    }
}
