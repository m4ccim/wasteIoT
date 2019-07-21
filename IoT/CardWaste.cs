using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT
{
    class CardWaste
    {
        public int CardWasteId { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int WasteId { get; set; }
        public Waste Waste { get; set; }
        public double Amount { get; set; }
    }
}
