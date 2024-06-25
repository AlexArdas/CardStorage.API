using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStorage.Common.Request
{
    public class UpdateCardRequest
    {
        public int CardDeckId { get; set; }
        public int Id { get; set; }
        public int Value { get; set; }
        public int Suit { get; set; }
    }
}
