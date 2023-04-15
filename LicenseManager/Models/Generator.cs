using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LicenseManager.Models
{
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
        public int TimesActivatedMax { get; set; }

        [JsonPropertyName("separator")]
        public string Separator { get; set; }

        [JsonPropertyName("prefix")]
        public string Prefix { get; set; }

        [JsonPropertyName("suffix")]
        public string Suffix { get; set; }

        [JsonPropertyName("expiresIn")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; }

        [JsonPropertyName("updatedAt")]
        public string UpdatedAt { get; set; }

        [JsonPropertyName("updatedBy")]
        public string UpdatedBy { get; set; }
    }
}
