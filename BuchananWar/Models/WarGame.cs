using BuchananWar.Models;

public class WarGame
{
    /// <summary>
    /// Represents the deck of cards used in the game.
    /// </summary>
    private Deck _deck;

    /// <summary>
    /// Represents the hands of all players.
    /// </summary>
    public PlayerHands _playerHands;

    /// <summary>
    /// The number of players participating in the game.
    /// </summary>
    private int _numberOfPlayers;

    /// <summary>
    /// The current round number of the game.
    /// </summary>
    private int _roundNumber;

    /// <summary>
    /// Gets the results of each round.
    /// </summary>
    public List<string> RoundResults { get; private set; }

    /// <summary>
    /// Stores cards in case of a tie during a round.
    /// </summary>
    private List<Card> _tiedCards;

    /// <summary>
    /// Initializes a new instance of the <see cref="WarGame"/> class.
    /// </summary>
    /// <param name="numberOfPlayers">The number of players, default is 2.</param>
    public WarGame(int numberOfPlayers = 2)
    {
        _numberOfPlayers = numberOfPlayers;
        _deck = new Deck(numberOfPlayers);
        _playerHands = new PlayerHands();
        RoundResults = new List<string>();
        _roundNumber = 1;
        _tiedCards = new List<Card>();
        _playerHands.Hands = _deck.Deal(numberOfPlayers);
    }

    /// <summary>
    /// Starts the game and plays rounds until a winner is determined or the game ends in a draw.
    /// </summary>
    /// <returns>A string indicating the result of the game.</returns>
    public string StartGame()
    {
        while (_playerHands.Hands.Values.All(hand => hand.Cards.Count > 0))
        {
            var roundResult = PlayRound();
            if (roundResult.Contains("wins the game"))
            {
                return roundResult;
            }
            _roundNumber++;
        }

        return string.Empty;
    }

    /// <summary>
    /// Plays a single round of the game and determines the result of the round.
    /// </summary>
    /// <returns>A string indicating the result of the round.</returns>
    public string PlayRound()
    {
        var roundCards = new Dictionary<string, Card>();
        var roundResult = $"Round {_roundNumber} - ";

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
            roundResult += $"{winner} wins the round!";
            foreach (var card in roundCards.Values)
            {
                _playerHands.Hands[winner].AddCard(card);
            }
            foreach (var card in _tiedCards)
            {
                _playerHands.Hands[winner].AddCard(card);
            }
            _tiedCards.Clear();

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
            roundResult += "It's a tie! Cards stay on the stack.";
            foreach (var card in roundCards.Values)
            {
                _tiedCards.Add(card);
            }
        }

        if (_playerHands.Hands.Values.All(hand => hand.Cards.Count == 0))
        {
            return "The game was a draw!";
        }

        if (_numberOfPlayers > 2)
        {
            var playersToRemove = _playerHands.Hands
                .Where(kv => kv.Value.Cards.Count == 0)
                .Select(kv => kv.Key)
                .ToList();

            foreach (var player in playersToRemove)
            {
                _playerHands.Hands.Remove(player);
                _numberOfPlayers--;
                roundResult += $"{player} has been removed from the game. ";
            }
        }

        if (RoundResults.Count > 0)
        {
            RoundResults.RemoveAt(0);
        }
        RoundResults.Add(roundResult);
        return roundResult;
    }

    /// <summary>
    /// Determines the winner of a round based on the highest card value.
    /// </summary>
    /// <param name="roundCards">The cards played in the current round.</param>
    /// <returns>The name of the winning player, or <c>null</c> if the round is a tie.</returns>
    private string DetermineRoundWinner(Dictionary<string, Card> roundCards)
    {
        var highestCardValue = roundCards.Values.Max(card => card.Value);
        var tiedPlayers = roundCards.Where(x => x.Value.Value == highestCardValue).Select(x => x.Key).ToList();

        if (tiedPlayers.Count > 1)
        {
            return null;
        }

        return tiedPlayers.First();
    }
}
