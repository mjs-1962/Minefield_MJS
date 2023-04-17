using Xunit;
using Minefield.Models;
using FluentValidation;
using Minefield.Services;
using System.Collections.Generic;

namespace MinefieldTests
{
    public class PlayerCreationTests
    {
        const int NoOfLivesForDifficultyEasy = 6;
        const int NoOfLivesForDifficultyMedium = 10;
        const int NoOfLivesForDifficultyDifficult = 15;
        const int GridSize = 8;


        [Theory]
        [InlineData("MJS", NoOfLivesForDifficultyEasy, 4, 4, "E5")]
        [InlineData("RJS", NoOfLivesForDifficultyMedium, 7, 5, "F8")]
        [InlineData("DLS", NoOfLivesForDifficultyDifficult, 3, 5, "F4")]
        public void PlayerIsCreated(string playerName, int livesRemaining, int newRow, int newColumn, string chessboardLocation)
        {
            //Arrange
            Player player = new Player(playerName, livesRemaining);

            //Act
            int initialColumn = player.CurrentColumn;
            int initialRow = player.CurrentRow;
            player.CurrentColumn = newColumn;
            player.CurrentRow = newRow;
            string _chesboardLocation = player.ChessboardLocation();
            int columnAdterChange = player.CurrentColumn;
            int RowAftrChange = player.CurrentRow;
            player.ResetLocation();
            int columnAfterReset = player.CurrentColumn;
            int RowAfterReset = player.CurrentRow;

            //Assert
            Assert.True(player.PlayerName == playerName);
            Assert.True(player.LivesRemaining == livesRemaining);
            Assert.True(initialColumn == 0);
            Assert.True(initialRow == 0);
            Assert.True(columnAdterChange == newColumn);
            Assert.True(RowAftrChange == newRow);
            Assert.True(columnAfterReset == 0);
            Assert.True(RowAfterReset >= 0 && RowAfterReset < GridSize);
            Assert.True(_chesboardLocation == chessboardLocation);


        }
    }
}