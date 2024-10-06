using PigDiceGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDiceGame.Controller
{

    internal class GameManager
    {
        private int currentTurnScore;
        private int totalScore;
        private Random random;

        public GameManager()
        {
            currentTurnScore = 0;
            totalScore = 0;
            random = new Random();
        }

        public string RollDice()
        {
            int roll = random.Next(1, 7);
            if (roll == 1)
            {
                currentTurnScore = 0;
                return "You rolled: 1\nTurn over. No Score";
            }
            else
            {
                currentTurnScore += roll;
                return $"You rolled: {roll}";
            }
        }

        public string Hold()
        {
            totalScore += currentTurnScore;
            string result = $"Your turn score is {currentTurnScore} and your total score is {totalScore}";
            currentTurnScore = 0;
            return result;
        }

        public int GetCurrentTurnScore() => currentTurnScore;
        public int GetTotalScore() => totalScore;
        public bool GameWon() => totalScore >= 20;
    }
}

