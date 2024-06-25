using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CardDeck
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
    }
}
