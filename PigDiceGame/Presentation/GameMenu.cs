using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using PigDiceGame.Controller;

namespace PigDiceGame.Presentation
{
    internal class GameMenu
    {
        const int DEFAULTCOUNT = 1;
        public static void Display()
        {
            Console.WriteLine("Let's Play PIG!");
            Console.WriteLine("See how many turns it takes you to get to 20.");
            Console.WriteLine("Turn ends when you hold or roll a 1.");
            Console.WriteLine("If you roll a 1, you lose all points for the turn.");
            Console.WriteLine("If you hold, you save all points for the turn.");
            int turnCount = DEFAULTCOUNT;
            
            GameManager gameManager = new GameManager();
            while (true)
            {
                Console.WriteLine($"\nTURN {turnCount}:");
                Console.WriteLine("Welcome to the game of Pig!");

                

                GiveChoice(gameManager, ref turnCount);
            }

        }
        static void GiveChoice(GameManager gameManager, ref int turnCount)
        {
            while (true)
            {
                Console.WriteLine("Enter 'r' to roll again, 'h' to hold.");
                string choice = Console.ReadLine().ToLower();

                CaseRollHold(choice, gameManager,ref turnCount);

                if(gameManager.GetCurrentTurnScore()==0 && choice == "r")
                {
                    Console.WriteLine("No points added.");
                    turnCount++;
                    break;
                }
                else if (choice == "h")
                {
                    turnCount++;
                    break;
                }
            }


        }
        static void CaseRollHold(string choice, GameManager gameManager, ref int turnCount)
        {
            switch (choice)
            {
                case "r":
                    string rollResult = gameManager.RollDice();
                    Console.WriteLine(rollResult);


                    if (gameManager.GameWon())
                    {
                        Console.WriteLine($"You Win! You finished in {turnCount} turns!");
                        Console.WriteLine("Game over!");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine($"Your turn score is {gameManager.GetCurrentTurnScore()} and your total score is {gameManager.GetTotalScore()}");
                        Console.WriteLine($"If you hold, you will have {gameManager.GetTotalScore() + gameManager.GetCurrentTurnScore()} points.");

                    }

                    break;


                case "h":
                    string holdResult = gameManager.Hold();
                    Console.WriteLine(holdResult);

                    if (gameManager.GameWon())
                    {
                        Console.WriteLine($"You Win! You finished in {turnCount} turns!\nGameOver!");
                        Environment.Exit(0);
                    }

                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter 'r' to roll or 'h' to hold.");
                    break;
            }
        }
    }
}
