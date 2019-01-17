using LudoGameEngine;
using LudoGameEngineTests.Mocks;
using Xunit;

namespace LudoGameEngineTests
{
    public class LudoGameTest
    {
        [Fact]
        public void AddPlayer_FirstPlayer_ReturnNotNull()
        {
            // Arrange
            var game = new LudoGame(new DieceMock());

            // Act
            var player = game.AddPlayer("player1", PlayerColor.Blue);

            // Assert
            Assert.NotNull(player);
            Assert.Equal(0, player.PlayerId);
        }

        [Fact]
        public void AddPlayer_TwoBluePlayers_SecondPlayerReturnNull()
        {
            // Arrange
            var game = new LudoGame(new DieceMock());

            // Act
            var player1 = game.AddPlayer("player1", PlayerColor.Blue);
            var player2 = game.AddPlayer("player2", PlayerColor.Blue);

            // Assert
            Assert.NotNull(player1);
            Assert.Null(player2);

            // Extra asserts
            Assert.Equal(0, player1.PlayerId);
        }


        [Fact]
        public void AddPlayer_TwoPlayersWithDifferentColors_BothPlayersNotNull()
        {
            // Arrange
            var game = new LudoGame(new DieceMock());

            // Act
            var player1 = game.AddPlayer("player1", PlayerColor.Blue);
            var player2 = game.AddPlayer("player2", PlayerColor.Red);

            // Assert
            Assert.NotNull(player1);
            Assert.NotNull(player2);

            // Extra asserts
            Assert.Equal(0, player1.PlayerId);
            Assert.Equal(1, player2.PlayerId);
        }


        [Fact]
        public void StartGame_TwoPlayers_GameStateIsStarted()
        {
            // Arrange
            var game = new LudoGame(new DieceMock());
            game.AddPlayer("player1", PlayerColor.Blue);
            game.AddPlayer("player2", PlayerColor.Red);

            // Act
            bool result = game.StartGame();

            // Assert
            Assert.True(result);
            Assert.Equal(GameState.Started, game.GetGameState());
        }
    }
}
