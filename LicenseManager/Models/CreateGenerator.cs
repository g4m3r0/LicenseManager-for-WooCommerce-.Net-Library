using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LicenseManager.Models
{
    public class CreateGenerator
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("charset")]
        public string Charset { get; set; }

        [JsonPropertyName("chunks")]
        public int Chunks { get; set; }

        [JsonPropertyName("chunk_length")]
        public int ChunkLength { get; set; }

        [JsonPropertyName("times_activated_max")]
        public int TimesActivatedMax { get; set; }

        [JsonPropertyName("separator")]
        public string Separator { get; set; }

        [JsonPropertyName("prefix")]
        public string Prefix { get; set; }

        [JsonPropertyName("suffix")]
        public string Suffix { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
