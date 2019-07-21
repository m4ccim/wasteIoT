using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT
{
    class Bill
    {
        public int BillId { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public DateTime DateTime { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }

        public bool IsCompleted { get; set; }
    }
}
