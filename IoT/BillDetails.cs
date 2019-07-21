using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT
{
    class BillDetails
    {
        public Bill Bill { get; set; }
        public List<ProductDetails> ProductDetails { get; set; }
    }

    class ProductDetails
    {
        public Product Product { get; set; }
        public double Amount { get; set; }
        public List<WasteDiscount> WasteDiscounts { get; set; }
    }

    class WasteDiscount
    {
        public Waste Waste { get; set; }
        public double DiscountedAmount { get; set; }
    }
}
