using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Services
{
    public class Player : IPlayer
    {

        public Player()
        {
        }

        public Player(string playerName, int livesForDifficultyLevel)
        {
            PlayerName = playerName;
            TotalLives = livesForDifficultyLevel;
            LivesRemaining = TotalLives;
        }

        public string? PlayerName { get; set; }

        public int TotalLives { get; set; }

        public int LivesRemaining { get; set; }




        public int CurrentRow { get; set; }
        public int CurrentColumn { get; set; }

        public void ResetLocation()
        {
            var rand = new Random();
            CurrentRow = rand.Next(0, 8);
            CurrentColumn = 0;
            LivesRemaining = TotalLives;

        }

        public string ChessboardLocation()
        {
            var _chessboardColumns = "ABCDEFGH";

            return _chessboardColumns.Substring(CurrentColumn, 1) + (CurrentRow + 1).ToString();

        }
        public bool MoveUp()
        {
            if (CurrentRow < 7)
            {
                CurrentRow++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MoveDown()
        {
            if (CurrentRow > 0)
            {
                CurrentRow--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MoveLeft()
        {
            if (CurrentColumn > 0)
            {
                CurrentColumn--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MoveRight()
        {
            if (CurrentColumn < 7)
            {
                CurrentColumn++;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
