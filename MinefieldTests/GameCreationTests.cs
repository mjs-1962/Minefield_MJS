using Xunit;
using Minefield.Models;
using FluentValidation;

namespace MinefieldTests
{
    public class GameCreationTests
    {
        
        [Theory]
        [InlineData("TestTitle","Test Description")]
        public void GameIsCreated(string? title, string? description)
        {
            //Arrange
            MinefieldGame newGame = new MinefieldGame(title, description);

            //Act

            //Assert
            Assert.True(newGame != null);
            Assert.True(string.IsNullOrWhiteSpace(newGame.Title) == false);
            Assert.True(string.IsNullOrWhiteSpace(newGame.Description) == false);
        }
    }
}