using Xunit;
using Minefield.Models;
using FluentValidation;
using Minefield.Services;
using System.Collections.Generic;

namespace MinefieldTests
{
    public class GameboardTests
    {
        const int ChessboardDimension = 8;

        [Theory]
        [InlineData(ChessboardDimension, 4)]
        public void GameboardIsCreated(int gridSize, int mineCell)
        {
            //Arrange
            GameBoard newGameboard = new GameBoard();
            List<int> mineCells = new List<int>() { mineCell};

            //Act
            List<List<bool>> defaultCells = newGameboard.InitialiseCells(gridSize);
            List<List<bool>> cellsWithMines = newGameboard.ApplyMinesToPlayingField(gridSize, defaultCells,mineCells );
            int gameBoardRow = newGameboard.GetRowFromInteger(gridSize, mineCell);
            int gameBoardColumn = newGameboard.GetColumnFromInteger(gridSize, mineCell);

            List<bool> currentRow = cellsWithMines[gameBoardRow];
            bool cellHasMine = currentRow[gameBoardColumn];

            //Assert
            Assert.True(newGameboard != null);
            Assert.True(cellHasMine == true);
            Assert.True(defaultCells.Count == gridSize);
            Assert.True(defaultCells[0].Count == gridSize);

           
        }
    }
}