using Xunit;
using Minefield.Models;
using FluentValidation;
using Minefield.Services;
using System.Collections.Generic;

namespace MinefieldTests
{
    public class MineCreationTests
    {
        const int InclusiveLowerMineCellSeedValue = 0;
        const int ExclusiveUpperMineCellSeedValue = 65;
        const int NoOfMinesForDifficltyEasy = 10;
        const int NoOfMinesForDifficltyMedium = 15;
        const int NoOfMinesForDifficltyDifficult = 20;


        [Theory]
        [InlineData(InclusiveLowerMineCellSeedValue, ExclusiveUpperMineCellSeedValue, NoOfMinesForDifficltyEasy)]
        [InlineData(InclusiveLowerMineCellSeedValue, ExclusiveUpperMineCellSeedValue, NoOfMinesForDifficltyMedium)]
        [InlineData(InclusiveLowerMineCellSeedValue, ExclusiveUpperMineCellSeedValue, NoOfMinesForDifficltyDifficult)]
        public void GameboardIsCreated(int inclusiveLowerMineCellSeedValue, int exclusiveUpperMineCellSeedValue, int integerCount)
        {
            //Arrange
            MineList mineList = new MineList();

            //Act
            List<int> mines = mineList.CreateUniqueMineList(inclusiveLowerMineCellSeedValue, exclusiveUpperMineCellSeedValue, integerCount);

            //Assert
            Assert.True(mines.Count == integerCount);
        }
    }
}