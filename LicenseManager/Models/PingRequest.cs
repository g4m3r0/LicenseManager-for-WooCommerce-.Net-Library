using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseManager.Models
{
    public class PingRequest
    {
        public string LicenseKey { get; set; }
        public string ProductName { get; set; }
        public string Host { get; set; }
    }
}
