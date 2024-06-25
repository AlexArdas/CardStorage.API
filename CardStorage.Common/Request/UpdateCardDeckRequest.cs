using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStorage.Common.Request
{
    public class UpdateCardDeckRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
