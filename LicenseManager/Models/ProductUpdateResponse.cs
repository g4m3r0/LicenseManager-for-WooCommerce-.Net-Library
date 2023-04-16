using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseManager.Models
{
    public class ProductUpdateResponse
    {
        public bool Success { get; set; }
        public ProductUpdate Data { get; set; }
    }
}
