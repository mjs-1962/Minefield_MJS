using Xunit;
using Minefield.Models;
using FluentValidation;
using Minefield.Services;
using System.Collections.Generic;

namespace MinefieldTests
{
    public class MineCreationTests
    {
        const int LowerMineCellValue = 0;
        const int UpperMineCellValue = 65;
        const int NoOfMinesForDifficltyEasy = 10;
        const int NoOfMinesForDifficltyMedium = 15;
        const int NoOfMinesForDifficltyDifficult = 20;


        [Theory]
        [InlineData(LowerMineCellValue, UpperMineCellValue, NoOfMinesForDifficltyEasy)]
        [InlineData(LowerMineCellValue, UpperMineCellValue, NoOfMinesForDifficltyMedium)]
        [InlineData(LowerMineCellValue, UpperMineCellValue, NoOfMinesForDifficltyDifficult)]
        public void GameboardIsCreated(int lowerMineCellValue, int upperMineCellValue, int integerCount)
        {
            //Arrange
            

            //Act

            //Assert
            //Assert.True(newGameboard != null);
            //Assert.True(cellHasMine == true);
            //Assert.True(defaultCells.Count == gridSize);
            //Assert.True(defaultCells[0].Count == gridSize);

            //Assert.True(string.IsNullOrWhiteSpace(newGame.Description) == false);
        }
    }
}