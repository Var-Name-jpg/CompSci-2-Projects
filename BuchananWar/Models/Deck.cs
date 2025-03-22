namespace BuchananWar.Models
{
    /// <summary>
    /// Represents a deck of cards used in the game.
    /// </summary>
    public class Deck
    {
        /// <summary>
        /// Gets or sets the stack of cards in the deck.
        /// </summary>
        public Stack<Card> Cards { get; set; }

        private Random _random;

        /// <summary>
        /// Initializes a new instance of the <see cref="Deck"/> class and populates it with 52 random cards.
        /// </summary>
        /// <param name="numberOfPlayers">The number of players, default is 2.</param>
        public Deck(int numberOfPlayers = 2)
        {
            _random = new Random();
            Cards = new Stack<Card>();
            var suits = new[] { "Hearts", "Diamonds", "Clubs", "Spades" };
            var ranks = new[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            // Generate 52 random cards
            for (int i = 0; i < 52; i++)
            {
                string rank = ranks[_random.Next(ranks.Length)];
                string suit = suits[_random.Next(suits.Length)];
                int value = Array.IndexOf(ranks, rank) + 2; // Values from 2 to 14 for Ace

                Cards.Push(new Card(suit, rank, value));
            }
        }

        /// <summary>
        /// Deals the cards in the deck among multiple players and creates their hands.
        /// </summary>
        /// <param name="numberOfPlayers">The number of players to deal cards to.</param>
        /// <returns>A dictionary where the key is the player's name and the value is their hand.</returns>
        public Dictionary<string, Hand> Deal(int numberOfPlayers)
        {
            var playerHands = new Dictionary<string, Hand>();

            // Create hands for each player
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                playerHands.Add($"Player {i}", new Hand());
            }

            // Distribute cards among players
            while (Cards.Count > 0)
            {
                foreach (var player in playerHands.Keys.ToList())
                {
                    if (Cards.Count > 0)
                    {
                        playerHands[player].AddCard(Cards.Pop());
                    }
                }
            }

            return playerHands;
        }
    }
}
