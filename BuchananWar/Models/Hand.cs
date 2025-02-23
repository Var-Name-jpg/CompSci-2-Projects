namespace BuchananWar.Models
{
    public class Hand
    {
        public Queue<Card> Cards { get; set; }

        public Hand()
        {
            Cards = new Queue<Card>();
        }

        // Add a card to the hand
        public void AddCard(Card card)
        {
            Cards.Enqueue(card);
        }

        // Remove and return the card at the front of the hand
        public Card PlayCard()
        {
            return Cards.Count > 0 ? Cards.Dequeue() : null;
        }

        // Add a list of cards to the end of the hand
        public void AddCards(List<Card> cards)
        {
            foreach (var card in cards)
            {
                Cards.Enqueue(card);
            }
        }
    }
}
