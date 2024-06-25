using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStorage.Common.Request
{
    public class CreateCardDeckRequest
    {
        public string Name { get; set; }
        public List<AddCardRequest> Cards { get; set; }
    }
}
