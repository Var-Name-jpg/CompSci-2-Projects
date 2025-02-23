namespace BuchananWar.Models
{
    public class Card
    {
        public string Suit { get; set; }
        public string Rank { get; set; }
        public int Value { get; set; } // This is used for comparison (2 to Ace)

        // Constructor for a card
        public Card(string suit, string rank, int value)
        {
            Suit = suit;
            Rank = rank;
            Value = value;
        }

        // Comparison method based on card value (Rank)
        public int CompareTo(Card other)
        {
            return Value.CompareTo(other.Value);
        }
    }

}
