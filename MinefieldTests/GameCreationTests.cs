using Xunit;
using Minefield.Models;
using FluentValidation;

namespace MinefieldTests
{
    public class GameCreationTests
    {
        const int DifficutyEasy = 0;
        const int DifficutyMedium = 1;
        const int DifficutyHard = 2;

        [Theory]
        [InlineData("TestTitle","Test Description", DifficutyEasy)]
        [InlineData("TestTitle", "Test Description", DifficutyMedium)]
        [InlineData("TestTitle", "Test Description", DifficutyHard)]
        public void GameIsCreated(string? title, string? description, int difficultyLevel)
        {
            //Arrange
            MinefieldGame newGame = new MinefieldGame(title, description, difficultyLevel);

            //Act

            //Assert
            Assert.True(newGame != null);
            Assert.True(string.IsNullOrWhiteSpace(newGame.Title) == false);
            Assert.True(string.IsNullOrWhiteSpace(newGame.Description) == false);
            Assert.True(newGame.DifficultyLevel == difficultyLevel);
        }
    }
}