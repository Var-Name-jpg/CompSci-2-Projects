namespace BuchananWar.Models
{
    /// <summary>
    /// Represents a player's hand of cards in the game.
    /// </summary>
    public class Hand
    {
        /// <summary>
        /// Gets or sets the queue of cards in the player's hand.
        /// </summary>
        public Queue<Card> Cards { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Hand"/> class.
        /// </summary>
        public Hand()
        {
            Cards = new Queue<Card>();
        }

        /// <summary>
        /// Adds a card to the player's hand.
        /// </summary>
        /// <param name="card">The card to be added.</param>
        public void AddCard(Card card)
        {
            Cards.Enqueue(card);
        }

        /// <summary>
        /// Removes and returns the card at the front of the player's hand.
        /// </summary>
        /// <returns>The card at the front of the hand, or <c>null</c> if the hand is empty.</returns>
        public Card PlayCard()
        {
            return Cards.Count > 0 ? Cards.Dequeue() : null;
        }

        /// <summary>
        /// Adds a list of cards to the end of the player's hand.
        /// </summary>
        /// <param name="cards">The list of cards to be added.</param>
        public void AddCards(List<Card> cards)
        {
            foreach (var card in cards)
            {
                Cards.Enqueue(card);
            }
        }
    }
}
