using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDiceGame.Model
{
    internal class Player
    {
        public string PlayerName { get; set; }
        public int TotalScore { get; private set; }
        public int CurrentTurnScore { get; set; }
        const int DEFAULT_TOTAL = 0;
        const int DEFAULT_SCORE = 0;
        public Player()
        {
            PlayerName = "Harshvardhan Gupta";
            TotalScore = DEFAULT_TOTAL;
            CurrentTurnScore = DEFAULT_SCORE;
            
        }

        public void AddToTotalScore()
        {
            TotalScore += CurrentTurnScore;
            ResetCurrentTurnScore();
        }

        public void AddToCurrentTurnScore(int score)
        {
            CurrentTurnScore += score;
        }

        

        public void ResetCurrentTurnScore()
        {
            CurrentTurnScore=DEFAULT_SCORE;
        }
    }
}
