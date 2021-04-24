using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public static class Extensions
    {
        public static void Enqueue(this Queue<Card> cards, Queue<Card> newCards)
        {
            foreach (var card in newCards) cards.Enqueue(card);
        }

        /// <summary>
        ///     Splits an array into several smaller arrays.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to split.</param>
        /// <param name="size">The size of the smaller arrays.</param>
        /// <returns>An array containing smaller arrays.</returns>
        public static IEnumerable<IEnumerable<T>> Split<T>(this T[] array, int size)
        {
            for (var i = 0; i < (float) array.Length / size; i++) yield return array.Skip(i * size).Take(size);
        }

        /// <summary>
        /// Divide cards equally to n number of players
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="numberOfPlayers"></param>
        /// <returns></returns>
        public static IEnumerable<Queue<Card>> CreateEqualCardDecks(this Queue<Card> cards, int numberOfPlayers)
        {
            var cardDecks = new List<Queue<Card>>();

            var cardsArray = cards.ToArray();
            var numberOfCardDecks = cards.Count() / numberOfPlayers;
            var cardArray = cardsArray.Split(numberOfCardDecks);

            foreach (var item in cardArray)
            {
                var cardDeck = new Queue<Card>();
                var dd = new Queue<Card>(item.Select(x => x));

                while (dd.Any()) cardDeck.Enqueue(dd.Dequeue());

                cardDecks.Add(cardDeck);
            }

            return cardDecks;
        }
    }
}