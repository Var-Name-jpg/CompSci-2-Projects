namespace BuchananWar.Models
{
    /// <summary>
    /// Represents a playing card with a suit, rank, and value.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Gets or sets the suit of the card (e.g., Hearts, Spades).
        /// </summary>
        public string Suit { get; set; }

        /// <summary>
        /// Gets or sets the rank of the card (e.g., 2, King, Ace).
        /// </summary>
        public string Rank { get; set; }

        /// <summary>
        /// Gets or sets the value of the card for comparison purposes (2 to Ace).
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class with specified suit, rank, and value.
        /// </summary>
        /// <param name="suit">The suit of the card.</param>
        /// <param name="rank">The rank of the card.</param>
        /// <param name="value">The value of the card for comparison.</param>
        public Card(string suit, string rank, int value)
        {
            Suit = suit;
            Rank = rank;
            Value = value;
        }

        /// <summary>
        /// Compares the value of the current card to another card.
        /// </summary>
        /// <param name="other">The card to compare with.</param>
        /// <returns>An integer indicating the comparison result:
        /// Less than zero if this card's value is less than the other card's value,
        /// zero if they are equal, and greater than zero if this card's value is greater.</returns>
        public int CompareTo(Card other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
