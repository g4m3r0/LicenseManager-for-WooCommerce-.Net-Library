using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseManager.Models
{
    public class LicenseDataModel
    {
        public int Id { get; set; } = 0;

        public int? OrderId { get; set; }

        public int ProductId { get; set; } = 0;

        public int? UserId { get; set; }

        public string LicenseKey { get; set; } = "";

        public string ExpiresAt { get; set; } = "";

        public int? ValidFor { get; set; }

        public int? Source { get; set; }

        public int? Status { get; set; }

        public int? TimesActivated { get; set; } = 0;
        public int? TimesActivatedMax { get; set; } = 0;
        public int? RemainingActivations { get; set; } = 0;

        public string CreatedAt { get; set; } = "";
        public int? CreatedBy { get; set; }
        public string UpdatedAt { get; set; } = "";
        public int? UpdatedBy { get; set; } = 0;
    }
}
