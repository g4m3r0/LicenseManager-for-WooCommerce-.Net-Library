using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json.Serialization;

namespace LicenseManager.Models
{
    public class GeneratorsResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("data")]
        public List<Generator> Data { get; set; }

    }
}
