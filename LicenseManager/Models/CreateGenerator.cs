namespace LicenseManager.Lib.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a create generator object containing information required to create a new generator configuration.
    /// </summary>
    public class CreateGenerator
    {
        /// <summary>
        /// Gets or sets the name of the generator.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the character set used by the generator.
        /// </summary>
        [JsonPropertyName("charset")]
        public string Charset { get; set; }

        /// <summary>
        /// Gets or sets the number of chunks in the generated output.
        /// </summary>
        [JsonPropertyName("chunks")]
        public int Chunks { get; set; }

        /// <summary>
        /// Gets or sets the length of each chunk in the generated output.
        /// </summary>
        [JsonPropertyName("chunk_length")]
        public int ChunkLength { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of times the generator can be activated.
        /// </summary>
        [JsonPropertyName("times_activated_max")]
        public int TimesActivatedMax { get; set; }

        /// <summary>
        /// Gets or sets the separator used between chunks in the generated output.
        /// </summary>
        [JsonPropertyName("separator")]
        public string Separator { get; set; }

        /// <summary>
        /// Gets or sets the prefix applied to the generated output.
        /// </summary>
        [JsonPropertyName("prefix")]
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets the suffix applied to the generated output.
        /// </summary>
        [JsonPropertyName("suffix")]
        public string Suffix { get; set; }

        /// <summary>
        /// Gets or sets the expiration interval in days for generated output.
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int? ExpiresIn { get; set; }
    }
}
