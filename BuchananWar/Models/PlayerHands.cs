namespace BuchananWar.Models
{
    public class PlayerHands
    {
        public Dictionary<string, Hand> Hands { get; set; }

        public PlayerHands(int numberOfPlayers = 2)
        {
            Hands = new Dictionary<string, Hand>();
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Hands.Add($"Player {i}", new Hand());
            }
        }

        // Get the hand of a specific player
        public Hand GetHand(string playerName)
        {
            return Hands.ContainsKey(playerName) ? Hands[playerName] : null;
        }
    }
}
