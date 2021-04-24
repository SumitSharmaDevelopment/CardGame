using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardGame;

namespace CardGame.Tests
{
    [TestClass]
    public class Task1TestCases
    {
        [TestMethod]
        public void New_Deck_Should_Contain_40Cards()
        {
           //Arrange
           var deckCreator = new DeckCreator();

           //Act
           var cards= deckCreator.CreateCards();

           //Assert
           var actualNumberOfCards = cards.Count;
           const int expectedNumberOfCards = 40;
           Assert.AreEqual(expectedNumberOfCards,actualNumberOfCards);
        }
    }
}
