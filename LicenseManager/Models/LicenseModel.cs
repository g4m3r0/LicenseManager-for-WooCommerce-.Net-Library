using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseManager.Models
{
    public class LicenseModel
    {
        public bool Success { get; set; } = false;
        public LicenseDataModel Data { get; set; }
    }
}
