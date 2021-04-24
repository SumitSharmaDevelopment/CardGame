using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CardGame
{
    public class Game
    {
        private readonly int _cardDeckNumber;
        private readonly ObservableCollection<Player> _listOfPlayers;
        private Queue<Card> _pool;
        public DeckCreator DeckCreator;

        public Game()
        {
        }

        /// <summary>
        /// Start the Game with Card Deck Creations and Assignment to the respective players
        /// </summary>
        /// <param name="players"></param>
        public Game(IEnumerable<string> players)
        {
            try
            {
                // Prepare list of Players with Additional Properties.
                _listOfPlayers = new ObservableCollection<Player>();
                foreach (var player in players) _listOfPlayers.Add(new Player(player));

                // Task 1: Create a shuffled deck of cards
                //Returns a shuffled set of cards
                DeckCreator = new DeckCreator();
                var cards = DeckCreator.CreateCards();
                var shuffledCards = DeckCreator.Shuffle(cards);
                var cardDecks = shuffledCards.CreateEqualCardDecks(_listOfPlayers.Count());

                var cardDeck = DeckCreator.CreateCards();
                var cardDeck1 = DeckCreator.CreateCards();

                var test = cardDeck.Equals(cardDeck1);

                foreach (var player in _listOfPlayers)
                {
                    if (cardDecks != null) player.Deal(cardDecks.ToList()[_cardDeckNumber]);
                    _cardDeckNumber++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Check whether anyone left with cards or not.
        /// </summary>
        /// <returns></returns>
        public bool IsEndOfGame()
        {
            foreach (var player in _listOfPlayers)
                if (!player.Draw.Any())
                {
                    var winner = _listOfPlayers.Where(x => x.Draw.Count > 0).Select(x => x.Name).First();
                    Console.WriteLine($"{winner} Wins the game!");
                    return true;
                }

            return false;
        }

        /// <summary>
        /// Initiate Players turn
        /// </summary>
        public void PlayTurn()
        {
            try
            {
                // Define a Pool to hold the card values for exchange
                _pool = _pool ?? new Queue<Card>();

                foreach (var item in _listOfPlayers)
                {
                    var player = item;
                    var playerCard = player.Draw.Dequeue();
                    player.Drawn = playerCard;
                    _pool.Enqueue(playerCard);

                    //Task 4: Console Output
                    Console.WriteLine(
                        $"{player.Name} ({player.Draw.Count() + player.Discard.Count() + 1} cards) : {playerCard.DisplayName}");

                    //Task 2: Draw cards
                    if (player.Draw.Count == 0)
                        if (player.Discard.Count > 0)
                            player = DeckCreator.RefillPlayerDeck(player);
                }

                // Task 3: Playing a turn
                //If both players has same cards. Then Add values in Pool and Print No Win message.
                var winner = FindRoundWinner(_listOfPlayers);
                if (winner != null)
                {
                    winner.Discard.Enqueue(_pool);
                    _pool.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, Console.ForegroundColor = ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Find Wound winner by passing Players game details
        /// </summary>
        /// <param name="listOfPlayers"></param>
        /// <returns></returns>
        public Player FindRoundWinner(IEnumerable<Player> listOfPlayers)
        {
            var draw = listOfPlayers.GroupBy(x => x.Drawn.Value).Any(g => g.Count() == listOfPlayers.Count());
            if (draw)
            {
                Console.WriteLine("No winner in this round!\n");
                return null;
            }

            // Biggest Card          
            var winner = listOfPlayers.OrderByDescending(x => x.Drawn.Value).First();
            Console.WriteLine($"{winner.Name} wins this round\n");
            return winner;
        }
    }
}