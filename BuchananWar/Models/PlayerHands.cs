namespace BuchananWar.Models
{
    /// <summary>
    /// Represents the collection of player hands in the game.
    /// </summary>
    public class PlayerHands
    {
        /// <summary>
        /// Gets or sets the dictionary of player hands, where the key is the player's name and the value is their hand.
        /// </summary>
        public Dictionary<string, Hand> Hands { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerHands"/> class with a specified number of players.
        /// </summary>
        /// <param name="numberOfPlayers">The number of players in the game. Default is 2.</param>
        public PlayerHands(int numberOfPlayers = 2)
        {
            Hands = new Dictionary<string, Hand>();
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Hands.Add($"Player {i}", new Hand());
            }
        }

        /// <summary>
        /// Retrieves the hand of a specific player.
        /// </summary>
        /// <param name="playerName">The name of the player.</param>
        /// <returns>The hand of the player, or <c>null</c> if the player is not found.</returns>
        public Hand GetHand(string playerName)
        {
            return Hands.ContainsKey(playerName) ? Hands[playerName] : null;
        }
    }
}
