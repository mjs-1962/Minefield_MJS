using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Services
{
    public class Display
    {
        private IGameBoard _gameBoard;
        private IMineList _mineList;
        private IPlayer _player;

        public Display(string title, string description, IGameBoard gameBoard, IMineList mineList, IPlayer player, int gridSize)
        {
            Title = title;
            Description = description;
            _gameBoard = gameBoard;
            _mineList = mineList;
            _player = player;
            _gridSize = gridSize;
        }

        public string Title { get; }
        public string Description { get; }
        int _gridSize { get; }

        public void Draw()
        {
            int _madeItAcross = _gridSize - 1;
            Console.Clear();

            if (_player.LivesRemaining == 0)
            {
                GameOver();
            }
            else if (_player.CurrentColumn == _madeItAcross)
            {
                GameSuccess();
            }
            else
            {
                mainDisplay();
            }
    }

    private void GameOver()
    {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("OOPS YOU'RE OUT OF LIVES");
            Console.WriteLine($"Lives remaining: {_player.LivesRemaining}");
            Console.WriteLine("User the * key to restart the game");
        }

        private void GameSuccess()
    {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("YOU DID IT");
            Console.WriteLine($"Lives remaining: {_player.LivesRemaining}");
            Console.WriteLine("User the * key to restart the game");

        }


        private void mainDisplay()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Player name: {_player.PlayerName}");
            Console.WriteLine($"Row / Column: {_player.CurrentRow} / {_player.CurrentColumn}");
            Console.WriteLine($"Cell: {_player.ChessboardLocation()}");
            Console.WriteLine($"Lives remaining: {_player.LivesRemaining}");
            Console.WriteLine("User the cursor keys to navigate and use the * key to restart the game");

        }
    }
}
