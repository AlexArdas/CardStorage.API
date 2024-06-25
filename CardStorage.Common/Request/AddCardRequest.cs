using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStorage.Common.Request
{
    public class AddCardRequest
    {
        public int Value { get; set; }
        public int Suit { get; set; }
        public int Order { get; set; }
        public int CardDeckId { get; set; }
    }
}
