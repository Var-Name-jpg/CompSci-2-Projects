using BuchananWar.Models;

public class WarGame
{
    private Deck _deck;
    public PlayerHands _playerHands;
    private int _numberOfPlayers;
    private int _roundNumber;
    public List<string> RoundResults { get; private set; }  // Store results of each round
    private List<Card> _tiedCards;  // Stack to store cards in case of a tie

    public WarGame(int numberOfPlayers = 2)
    {
        _numberOfPlayers = numberOfPlayers;
        _deck = new Deck(numberOfPlayers);
        _playerHands = new PlayerHands();
        RoundResults = new List<string>();  // Initialize the round results list
        _roundNumber = 1;
        _tiedCards = new List<Card>();  // Initialize the tied cards stack
        _playerHands.Hands = _deck.Deal(numberOfPlayers);
    }

    public string StartGame()
    {
        while (_playerHands.Hands.Values.All(hand => hand.Cards.Count > 0))
        {
            var roundResult = PlayRound();
            if (roundResult.Contains("wins the game"))
            {
                return roundResult; // Early return if someone wins
            }
            _roundNumber++;
        }

        return string.Empty; // If no winner by the end of the game
    }

    public string PlayRound()
    {
        var roundCards = new Dictionary<string, Card>();
        var roundResult = $"Round {_roundNumber} - ";

        // Each player plays a card
        foreach (var player in _playerHands.Hands.Keys.ToList())
        {
            if (_playerHands.Hands[player].Cards.Count > 0)
            {
                var card = _playerHands.Hands[player].PlayCard();
                roundCards.Add(player, card);
                roundResult += $"{player} played {card.Rank} of {card.Suit}, ";
            }
        }

        var winner = DetermineRoundWinner(roundCards);
        if (winner != null)
        {
            // If there is a winner, they get all the cards from the round, including the tied cards
            roundResult += $"{winner} wins the round!";
            // Give the winner the current round's cards *plus* any cards in the tied stack
            foreach (var card in roundCards.Values)
            {
                _playerHands.Hands[winner].AddCard(card);
            }
            foreach (var card in _tiedCards)
            {
                _playerHands.Hands[winner].AddCard(card);
            }
            _tiedCards.Clear();  // Clear the tied cards stack after the round is settled

            // Check if any player has 52 cards (winning condition)
            foreach (var hand in _playerHands.Hands)
            {
                if (hand.Value.Cards.Count == 52)
                {
                    return $"{hand.Key} wins the game with 52 cards!";
                }
            }
        }
        else
        {
            // It's a tie, cards stay in the stack for the next round
            roundResult += "It's a tie! Cards stay on the stack.";
            foreach (var card in roundCards.Values)
            {
                _tiedCards.Add(card);
            }
        }

        // Check if both players have zero cards left (draw condition)
        if (_playerHands.Hands.Values.All(hand => hand.Cards.Count == 0))
        {
            return "The game was a draw!";
        }

        // Remove players with empty hands if there are more than 2 players
        if (_numberOfPlayers > 2)
        {
            var playersToRemove = _playerHands.Hands
                .Where(kv => kv.Value.Cards.Count == 0)
                .Select(kv => kv.Key)
                .ToList();

            foreach (var player in playersToRemove)
            {
                _playerHands.Hands.Remove(player);
                _numberOfPlayers--; // Decrease the number of players
                roundResult += $"{player} has been removed from the game. ";
            }
        }

        // Store round result
        if (RoundResults.Count > 0)
        {
            RoundResults.RemoveAt(0);
        }
        RoundResults.Add(roundResult);  // Add result to the list
        return roundResult;  // Return the result to be shown on the UI
    }

    private string DetermineRoundWinner(Dictionary<string, Card> roundCards)
    {
        // Find the highest card value
        var highestCardValue = roundCards.Values.Max(card => card.Value);

        // Find all players who have the highest card value
        var tiedPlayers = roundCards.Where(x => x.Value.Value == highestCardValue).Select(x => x.Key).ToList();

        // If more than one player has the highest card value, it's a tie
        if (tiedPlayers.Count > 1)
        {
            return null; // Tie case
        }

        // Only one player has the highest card, so they win
        return tiedPlayers.First();
    }
}
