using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApplication.Models
{
    public class SaleModel
    {
        public IEnumerable<Product> Products { get; set; }
        public List<SaleItem> SaleItems { get; set; }
        public decimal totalPayment { get; set; }
    }
}