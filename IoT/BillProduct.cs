using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT
{
    class BillProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double Amount { get; set; }
        public int BillId { get; set; }
        public Bill Bill { get; set; }
    }
}
