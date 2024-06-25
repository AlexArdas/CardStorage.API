using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStorage.Common.Response
{
    public class GetCardDeckResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GetCardResponse> Cards { get; set; }
    }
}
