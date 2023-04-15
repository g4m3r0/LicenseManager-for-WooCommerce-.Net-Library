using System;
using System.Collections.Generic;
using System.Text;

namespace LicenseManager.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string SalePrice { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public Availability Availability { get; set; }
    }
}
