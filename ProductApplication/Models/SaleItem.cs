using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApplication.Models
{
    public class SaleItem
    {
        public Product ProductItem { get; set; }
        public int Quantity { get; set; }
    }
}