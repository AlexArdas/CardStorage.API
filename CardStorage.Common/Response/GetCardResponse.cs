namespace CardStorage.Common.Response
{
    public class GetCardResponse
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Suit { get; set; }
        public int Order { get; set; }
        public int CardDeckId { get; set; }
    }
}
