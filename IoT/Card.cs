using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT
{
    class Card
    {
        public int CardId { get; set; }
        public string CardOwnerName { get; set; }
        public double Balance { get; set; }
        public string Email { get; set; }

        public bool IsAdmin { get; set; }
        public string PasswordHash { get; set; }
    }
}
