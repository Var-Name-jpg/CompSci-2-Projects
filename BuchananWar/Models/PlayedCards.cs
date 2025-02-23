namespace BuchananWar.Models
{
    public class PlayedCards
    {
        public Dictionary<string, Card> Cards { get; set; }

        public PlayedCards()
        {
            Cards = new Dictionary<string, Card>();
        }

        // Add a card for the player
        public void AddCard(string playerName, Card card)
        {
            Cards[playerName] = card;
        }
    }

}
