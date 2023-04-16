using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LicenseManager.Models
{
    public class GeneratorGenerateResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("data")]
        public List<string> Data { get; set; }
    }
}
