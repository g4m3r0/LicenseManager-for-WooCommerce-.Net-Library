using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LicenseManager.Models
{
    public class LicenseValidationResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("data")]
        public LicenseValidationData Data { get; set; }
    }
}
