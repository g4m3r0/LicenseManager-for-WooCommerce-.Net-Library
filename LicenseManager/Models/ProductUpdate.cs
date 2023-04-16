using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseManager.Models
{
    public class ProductUpdate
    {
        public string LicenseKey { get; set; }
        public string Url { get; set; }
        public string NewVersion { get; set; }
        public string Package { get; set; }
        public string Tested { get; set; }
        public string Requires { get; set; }
        public string RequiresPhp { get; set; }
        public object LastUpdated { get; set; }
        public object Rating { get; set; }
        public int NumRatings { get; set; }
        public ProductUpdateSections Sections { get; set; }
    }
}
