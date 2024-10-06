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
        public int CurrentTurnScore { get; private set; }
        public int TurnCount { get; private set; }

        public Player()
        {
            PlayerName = "Player"; // Default name
            TotalScore = 0;
            CurrentTurnScore = 0;
            TurnCount = 0; // Initializing TurnCount
        }

        public void AddToTotalScore(int score)
        {
            TotalScore += score;
        }

        public void AddToCurrentTurnScore(int score)
        {
            CurrentTurnScore += score;
        }

        public void SetCurrentTurnScore(int score)
        {
            CurrentTurnScore = score;
        }

        

        public int GetTotalScore()
        {
            return TotalScore;
        }

        public int GetCurrentTurnScore()
        {
            return CurrentTurnScore;
        }
    }
}
