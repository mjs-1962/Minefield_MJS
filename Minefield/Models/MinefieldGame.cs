using Minefield.Services;
using System.Numerics;

namespace Minefield.Models
{
    public class MinefieldGame : BaseGame
    {
        private IGameBoard _gameBoard;
        private IMineList _mineList;
        private IPlayer _player;

        public MinefieldGame(string title, string description, int difficultyLevel)
        {
            Title = title;
            Description = description;
            DifficultyLevel = difficultyLevel;
        }

        public MinefieldGame(string title, string description, int difficultyLevel, int gridSize, IGameBoard gameBoard, IMineList mineList, IPlayer player)
        {
            Title = title;
            Description = description;
            _gameBoard = gameBoard;
            _mineList = mineList;
            _player = player;
            _gridSize = gridSize;
            DifficultyLevel = difficultyLevel;
            _player.TotalLives = GetNoOfLivesFromDifficultyLevel();
            _player.LivesRemaining = _player.TotalLives;
        }

        public int DifficultyLevel { get; set; }

        int _gridSize { get; set; }

        //public int CurrentRow { get; set; }
        //public int CurrentColumn { get; set; }

        List<List<bool>> cells { get; set; }

    

        public void ResetPlayingField()
        {
            cells = _gameBoard.InitialiseCells(_gridSize);
        }

        List<int> _randomMineCells = new List<int>();

        public void CreateMineList()
        {
            _randomMineCells = _mineList.CreateUniqueMineList(0, (_gridSize * _gridSize), GetNoOfMinesFromDifficultyLevel());

        }

        private int GetNoOfMinesFromDifficultyLevel()
        {
            switch (DifficultyLevel)
            {
                case 0: return 10;

                case 1: return 15;

                case 2: return 25;

                default: return 0;

            }

        }

        public void ApplyMinesToPlayingField()
        {
           _gameBoard.ApplyMinesToPlayingField(_gridSize, cells, _randomMineCells);
        }

        public int GetNoOfLivesFromDifficultyLevel()
        {
            switch (DifficultyLevel)
            {
                case 0: return 5;

                case 1: return 5;

                case 2: return 5;

                default: return 0;
            }
        }

        public void PlayerMove(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    _player.MoveDown();
                
                    break;

                case ConsoleKey.UpArrow:
                    _player.MoveUp();
                    break;

                case ConsoleKey.LeftArrow:
                    _player.MoveLeft();
                    break;

                case ConsoleKey.RightArrow:
                    _player.MoveRight();
                    break;

                case ConsoleKey.Multiply:
                    _player.ResetLocation();
                    Console.Clear();
                    break;


            }
            CheckForMine();
        }

        private void CheckForMine()
        {
            List<bool> currentRow = cells[_player.CurrentRow];

            if (currentRow[_player.CurrentColumn] && _player.LivesRemaining > 0)
            {
                _player.LivesRemaining--;
                currentRow[_player.CurrentColumn] = false;
            }

        }


    }
}