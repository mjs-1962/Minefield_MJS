using Minefield.Services;

namespace Minefield.Models
{
    public class MinefieldGame : BaseGame
    {
        private IGameBoard _gameBoard;
        private IMineList _mineList;
       

        public MinefieldGame(string title, string description, int difficultyLevel)
        {
            Title = title;
            Description = description;
        }

        public MinefieldGame(string title, string description, int difficultyLevel, int gridSize, IGameBoard gameBoard, IMineList mineList)
        {
            Title = title;
            Description = description;
            _gameBoard = gameBoard;
            _mineList = mineList;
            _gridSize = gridSize;
            DifficultyLevel = difficultyLevel;
        }

        public int DifficultyLevel { get; set; }

        int _gridSize { get; set; }

        public int CurrentRow { get; set; }
        public int CurrentColumn { get; set; }

        List<List<bool>> cells { get; set; }
        
        public void ResetPlayingField()
        {
            cells = _gameBoard.InitialiseCells(_gridSize);
        }

        List<int> _randomMineCells = new List<int>();

        public void CreateMineList()
        {
            _randomMineCells = _mineList.CreateUniqueMineList(0, (_gridSize * _gridSize) + 1, GetNoOfMinesFromDifficultyLevel());

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


    }
}