using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseManager.Models
{
    class LicenseDataModel
    {
        public string Id { get; set; } = string.Empty;

        public string OrderId { get; set; } = string.Empty;

        public string ProductId { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        public string LicenseKey { get; set; } = string.Empty;

        public string ExpiresAt { get; set; } = string.Empty;

        public string ValidFor { get; set; } = string.Empty;

        public string Source { get; set; } = string.Empty;

        public int Status { get; set; } = 0;

        public int TimesActivated { get; set; } = 0;
        public int TimesActivatedMax { get; set; } = 0;
        public int RemainingActivations { get; set; } = 0; //todo: unused remove?

        public string CreatedAt { get; set; } = string.Empty;
        public int CreatedBy { get; set; } = 0;
        public string UpdatedAt { get; set; } = string.Empty;
        public int UpdatedBy { get; set; } = 0;
    }
}
