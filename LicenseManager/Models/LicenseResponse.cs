namespace LicenseManager.Models
{
    using System.Collections.Generic;

    public class LicenseResponse
    {
        public bool Success { get; set; } = false;
        public List<License> Data { get; set; }
    }
}