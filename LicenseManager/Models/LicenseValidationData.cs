using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LicenseManager.Models
{
    public class LicenseValidationData
    {
        [JsonPropertyName("timesActivated")]
        public int? TimesActivated { get; set; }

        [JsonPropertyName("timesActivatedMax")]
        public int? TimesActivatedMax { get; set; }

        [JsonPropertyName("remainingActivations")]
        public int? RemainingActivations { get; set; }

        [JsonPropertyName("product")]
        public Product Product { get; set; }
    }
}
