namespace DeckOfCardsApiLab.Models
{
    public class CardSelection
    {
        public string success { get; set; }
        public string deck_id  { get; set; }
        public List<Card> cards {get; set;}
        public int remaining { get; set; }

    }
}
