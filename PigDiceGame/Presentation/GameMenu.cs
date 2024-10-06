using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PigDiceGame.Controller;

namespace PigDiceGame.Presentation
{
    internal class GameMenu
    {
        public static void Display()
        {
            Console.WriteLine("Let's Play PIG!");
            Console.WriteLine("See how many turns it takes you to get to 20.");
            Console.WriteLine("Turn ends when you hold or roll a 1.");
            Console.WriteLine("If you roll a 1, you lose all points for the turn.");
            Console.WriteLine("If you hold, you save all points for the turn.");

            int turnCount = 1;

            while (true)
            {
                Console.WriteLine($"\nTURN {turnCount}:");
                Console.WriteLine("Welcome to the game of Pig!");

                GameManager gameManager = new GameManager();

                while (true)
                {
                    Console.WriteLine("Enter 'r' to roll again, 'h' to hold.");
                    string choice = Console.ReadLine().ToLower();

                    switch (choice)
                    {
                        case "r":
                            string rollResult = gameManager.RollDice();
                            Console.WriteLine(rollResult);

                            if (gameManager.GameWon())
                            {
                                Console.WriteLine($"You Win! You finished in {turnCount} turns!");
                                Console.WriteLine("Game over!");
                                return;
                            }

                            Console.WriteLine($"Your turn score is {gameManager.GetCurrentTurnScore()} and your total score is {gameManager.GetTotalScore()}");
                            Console.WriteLine($"If you hold, you will have {gameManager.GetTotalScore() + gameManager.GetCurrentTurnScore()} points.");
                            break;

                        case "h":
                            var holdResult = gameManager.Hold();
                            Console.WriteLine(holdResult.result);

                            if (holdResult.isWin)
                            {
                                Console.WriteLine($"You Win! You finished in {turnCount} turns!");
                                Console.WriteLine("Game over!");
                                return;
                            }

                            turnCount++;
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please enter 'r' to roll or 'h' to hold.");
                            break;
                    }

                    if (gameManager.GetCurrentTurnScore() == 0 && choice == "r")
                    {
                        break;
                    }
                }
            }
        }
    }
}
