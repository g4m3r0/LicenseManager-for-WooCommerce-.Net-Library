namespace LicenseManager.Models
{
    using System;

    public class License
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string LicenseKey { get; set; }
        public DateTime ExpiresAt { get; set; }
        public int ValidFor { get; set; }
        public int Source { get; set; }
        public int Status { get; set; }
        public int? TimesActivated { get; set; }
        public int TimesActivatedMax { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
    }
}