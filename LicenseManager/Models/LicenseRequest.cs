using System;

namespace LicenseManager.Models
{
    public class LicenseRequest
    {
        public int ProductId { get; set; }
        public string LicenseKey { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public string Status { get; set; }
        public int? TimesActivatedMax { get; set; }
        public int? UserId { get; set; }
    }
}
