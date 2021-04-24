using System.Collections.Generic;

namespace CardGame
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public Queue<Card> Draw { get; set; } = new Queue<Card>();
        public Card Drawn { get; set; } = new Card();
        public Queue<Card> Discard { get; set; } = new Queue<Card>();

        public void Deal(Queue<Card> cards)
        {
            Draw = cards;
        }
    }
}