using System;
using System.Collections.Generic;

namespace CardGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("||||||||||||||| Game Begins |||||||||||||||\n");

                // Start game with Player name list
                // Pass collection of players
                var game = new Game(new List<string> {"Player 1", "Player 2"});

                while (!game.IsEndOfGame()) game.PlayTurn();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, Console.ForegroundColor = ConsoleColor.Red);
            }

            Console.ReadKey();
        }
    }
}