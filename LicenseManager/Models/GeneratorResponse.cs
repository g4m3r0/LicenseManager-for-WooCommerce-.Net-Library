﻿using System.Text.Json.Serialization;

namespace LicenseManager.Models
{
    public class GeneratorResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("data")]
        public Generator Data { get; set; }
    }
}
