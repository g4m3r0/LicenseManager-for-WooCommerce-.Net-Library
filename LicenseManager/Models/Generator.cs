namespace LicenseManagerClient.Lib.Models
{
    using System;
    using System.Text.Json.Serialization;
    using JsonConverter;

    public class Generator
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("charset")]
        public string Charset { get; set; }

        [JsonPropertyName("chunks")]
        public int Chunks { get; set; }

        [JsonPropertyName("chunkLength")]
        public int ChunkLength { get; set; }

        [JsonPropertyName("timesActivatedMax")]
        public string TimesActivatedMax { get; set; }

        [JsonPropertyName("separator")]
        public string Separator { get; set; }

        [JsonPropertyName("prefix")]
        public string Prefix { get; set; }

        [JsonPropertyName("suffix")]
        public string Suffix { get; set; }

        [JsonPropertyName("expiresIn")]
        public string ExpiresIn { get; set; }

        [JsonPropertyName("createdAt")]
        [JsonConverter(typeof(CustomDateTimeJsonConverter))]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; }

        [JsonPropertyName("updatedAt")]
        [JsonConverter(typeof(CustomDateTimeJsonConverter))]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("updatedBy")]
        public string UpdatedBy { get; set; }
    }
}
