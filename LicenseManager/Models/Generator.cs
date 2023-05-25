namespace LicenseManager.Lib.Models
{
    using System;
    using System.Text.Json.Serialization;
    using global::LicenseManager.Lib.JsonConverter;

    /// <summary>
    /// Represents a generator object containing information about a specific generator configuration.
    /// </summary>
    public class Generator
    {
        /// <summary>
        /// Gets or sets the identifier of the generator.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

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
        [JsonPropertyName("chunkLength")]
        public int ChunkLength { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of times the generator can be activated.
        /// </summary>
        [JsonPropertyName("timesActivatedMax")]
        public string TimesActivatedMax { get; set; }

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
        /// Gets or sets the expiration interval for generated output.
        /// </summary>
        [JsonPropertyName("expiresIn")]
        public string ExpiresIn { get; set; }

        /// <summary>
        /// Gets or sets the creation timestamp of the generator.
        /// </summary>
        [JsonPropertyName("createdAt")]
        [JsonConverter(typeof(CustomDateTimeJsonConverter))]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the user who created the generator.
        /// </summary>
        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the update timestamp of the generator.
        /// </summary>
        [JsonPropertyName("updatedAt")]
        [JsonConverter(typeof(CustomDateTimeJsonConverter))]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the user who last updated the generator.
        /// </summary>
        [JsonPropertyName("updatedBy")]
        public string UpdatedBy { get; set; }
    }
}
