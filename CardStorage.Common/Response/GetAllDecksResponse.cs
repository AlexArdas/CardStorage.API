using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardStorage.Common.Response
{
    public class GetAllDecksResponse
    {
        public List<GetCardDeckResponse> CardDecks { get; set; }
    }
}
