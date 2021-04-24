using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardGame;

namespace CardGame.Tests
{
    /// <summary>
    /// Summary description for Task3TestCases
    /// </summary>
    [TestClass]
    public class Task3TestCases
    {
        [TestMethod]
        public void Bigger_Card_Player_Should_Win()
        {
            // Assign
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");

            player1.Discard = new Queue<Card>();
            player1.Draw = new Queue<Card>();
            player1.Drawn.Value = 1;

            player2.Discard = new Queue<Card>();
            player2.Draw = new Queue<Card>();
            player2.Drawn.Value = 2;

            //Act
            var listOFPlayers = new List<Player>() {player1, player2};
            Game game = new Game();
            var winner = game.FindRoundWinner(listOFPlayers);

            var actualMessage = winner;
            var expectedMessage = player2;

            //Assert
            if (winner != null)
            {
                Assert.AreEqual(actualMessage.Name,expectedMessage.Name);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void InCase_Of_Draw_4Cards_Should_Added_Into_WinnerDrawCardPile()
        {
            // Assign
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");

            player1.Discard = new Queue<Card>();
            player1.Draw = new Queue<Card>();
            player1.Drawn.Value = 2;

            player2.Discard = new Queue<Card>();
            player2.Draw = new Queue<Card>();
            player2.Drawn.Value = 2;

            //Act
            var listOFPlayers = new List<Player>() { player1, player2 };
            Game game = new Game();
            var expectedResult = game.FindRoundWinner(listOFPlayers);

            //Assert
            Assert.IsNull(expectedResult);
        }
    }
}
