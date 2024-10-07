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
        
        const int DEFAULT_TARGET = 20;
        const int DEFAULT_START_SCORE=0;
        const int DEFAULT_TOTAL=0;
        Random random;
        Player player;

        public GameManager()
        {
            player = new Player();
            random = new Random();
        }

        public string RollDice()
        {
            int roll = random.Next(1, 7);
            if (roll == 1)
            {
                player.ResetCurrentTurnScore();
                return "You rolled: 1\nTurn over. No Score";
            }
            else
            {
                player.AddToCurrentTurnScore(roll);
                return $"You rolled: {roll}";
            }
        }

        public string Hold()
        {
            player.AddToTotalScore();
            return "Your turn score is now 0 and your total score is " + player.TotalScore;
        }

        public int GetCurrentTurnScore()
        {
            return player.CurrentTurnScore;
        }
        public int GetTotalScore()
        {
            return player.TotalScore;
        }
        public bool GameWon()
        {
            int targetScore = DEFAULT_TARGET;
            if(player.TotalScore>targetScore)
                return true;
            return false;
        } 
    }
}

