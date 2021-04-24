using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public class DeckCreator
    {
        public Queue<Card> CreateCards()
        {
            var cards = new Queue<Card>();
            try
            {
                for (var i = 1; i <= 10; i++)
                    foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                        cards.Enqueue(new Card
                        {
                            Value = i,
                            DisplayName = i.ToString()
                        });
                return cards;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public Queue<Card> CreateCards(int startingCardNumber, int endingCardNumber)
        //{
        //    try
        //    {
        //        var cards = new Queue<Card>();

        //        if (startingCardNumber < endingCardNumber && startingCardNumber >= 2 && endingCardNumber <= 14)
        //            for (var i = startingCardNumber; i <= endingCardNumber; i++)
        //                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        //                    cards.Enqueue(new Card
        //                    {
        //                        Suit = suit,
        //                        Value = i,
        //                        DisplayName = GetShortName(i, suit)
        //                    });
        //        else
        //            throw new Exception("Card range should fall under 2 to 14.");

        //        return Shuffle(cards);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public Queue<Card> Shuffle(Queue<Card> cards)
        {
            //Shuffle the existing cards using Fisher-Yates Modern
            var transformedCards = cards.ToList();
            var r = new Random(DateTime.Now.Millisecond);
            for (var n = transformedCards.Count - 1; n > 0; --n)
            {
                //Step 2: Randomly pick a card which has not been shuffled
                var k = r.Next(n + 1);

                //Step 3: Swap the selected item with the last "unselected" card in the collection
                var temp = transformedCards[n];
                transformedCards[n] = transformedCards[k];
                transformedCards[k] = temp;
            }

            var shuffledCards = new Queue<Card>();
            foreach (var card in transformedCards) shuffledCards.Enqueue(card);

            return shuffledCards;
        }

        /// <summary>
        ///     Logic for Suits
        /// </summary>
        /// <param name="value"></param>
        /// <param name="suit"></param>
        /// <returns></returns>
        public string GetShortName(int value, Suit suit)
        {
            var valueDisplay = "";
            if (value >= 2 && value <= 10)
                valueDisplay = value.ToString();
            else
                switch (value)
                {
                    case 11:
                        valueDisplay = "J";
                        break;
                    case 12:
                        valueDisplay = "Q";
                        break;
                    case 13:
                        valueDisplay = "K";
                        break;
                    case 14:
                        valueDisplay = "A";
                        break;
                }

            return valueDisplay + Enum.GetName(typeof(Suit), suit)[0];
        }

        public Player RefillPlayerDeck(Player player)
        {
            var draw = Shuffle(player.Discard);
            player.Draw.Enqueue(draw);
            player.Discard.Clear();
            return player;
        }
    }
}