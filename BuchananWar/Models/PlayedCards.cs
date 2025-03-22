namespace BuchananWar.Models
{
    /// <summary>
    /// Represents the cards played by players during a round.
    /// </summary>
    public class PlayedCards
    {
        /// <summary>
        /// Gets or sets the dictionary of cards played by players, where the key is the player's name and the value is their card.
        /// </summary>
        public Dictionary<string, Card> Cards { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayedCards"/> class.
        /// </summary>
        public PlayedCards()
        {
            Cards = new Dictionary<string, Card>();
        }

        /// <summary>
        /// Adds a card for a specific player to the collection of played cards.
        /// </summary>
        /// <param name="playerName">The name of the player.</param>
        /// <param name="card">The card played by the player.</param>
        public void AddCard(string playerName, Card card)
        {
            Cards[playerName] = card;
        }
    }
}
