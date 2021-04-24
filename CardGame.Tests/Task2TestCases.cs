using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardGame;

namespace CardGame.Tests
{
    /// <summary>
    /// Summary description for Task2TestCases
    /// </summary>
    [TestClass]
    public class Task2TestCases
    {
        [TestMethod]
        public void DiscardPileShuffledIntoDrawPile()
        {
            //Arrange
            var deckCreator = new DeckCreator();
            var player = new Player("Player 1")
            {
                Draw = new Queue<Card>(),
                Discard = deckCreator.CreateCards()
            };

            //Act
            var discardCardPile = deckCreator.RefillPlayerDeck(player);

            //Assert
            Assert.IsTrue(discardCardPile.Draw.Count > 0);
        }
    }
}
