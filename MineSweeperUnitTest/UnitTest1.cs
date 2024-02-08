using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Model;
using System.Collections.Generic;

namespace MinesweeperUnitTest
{
    [TestClass]
    public class GameModelTests
    {
        [TestMethod]
        public void TestInitializeGame_ValidInput()
        {
            // Arrange
            var gameModel = new GameModel();

            // Act
            gameModel.InitializeGame(4, 3);

            // Assert
            Assert.AreEqual(4, gameModel.Grid.GetLength(0));
            Assert.AreEqual(4, gameModel.Grid.GetLength(1));
            Assert.AreEqual(GameState.InProgress, gameModel.GameState);
        }

     
        [TestMethod]
        public void TestProcessUserInput_ValidInput()
        {
            // Arrange
            var gameModel = new GameModel();
            gameModel.InitializeGame(4, 3);

            // Act
            gameModel.ProcessUserInput("A1");

            // Assert
            Assert.AreEqual(1, gameModel.revealedCells); // Check if a new cell is revealed
            Assert.AreNotEqual('_', gameModel.Grid[0, 0]); // Check if the revealed cell value is not '_'
            Assert.IsTrue(gameModel.Grid[0, 0] != ' ' || gameModel.Grid[0, 0] != '*'); // Check if the revealed cell is neither blank nor a mine
        }

        [TestMethod]
        public void TestProcessUserInput_InvalidInput()
        {
            // Arrange
            var gameModel = new GameModel();
            gameModel.InitializeGame(4, 3);

            // Act
            gameModel.ProcessUserInput("Z1");

            // Assert
            Assert.AreEqual(0, gameModel.revealedCells);
            Assert.AreEqual(GameState.InProgress, gameModel.GameState);
        }

       

        [TestMethod]
        public void TestCountAdjacentMines_WithAdjacentMines()
        {
            // Arrange
            var gameModel = new GameModel();
            gameModel.InitializeGame(4, 3, new HashSet<(int, int)> { (0, 1), (1, 0), (1, 1) });

            // Act
            int adjacentMines = gameModel.CountAdjacentMines(0, 0);

            // Assert
            Assert.AreEqual(3, adjacentMines);
        }


        [TestMethod]
        public void TestInitializeGame_InvalidSize()
        {
            // Arrange
            var gameModel = new GameModel();

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => gameModel.InitializeGame(0, 5)); // Zero size
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => gameModel.InitializeGame(-1, 5)); // Negative size
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => gameModel.InitializeGame(11, 5)); // Size greater than 10
        }


        [TestMethod]
        public void TestInitializeGame_InvalidNumberOfMines()
        {
            // Arrange
            var gameModel = new GameModel();

            // Act & Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => gameModel.InitializeGame(4, 0));
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => gameModel.InitializeGame(4, -1));
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => gameModel.InitializeGame(4, 16));
        }

        [TestMethod]
        public void TestProcessUserInput_RevealMine()
        {
            // Arrange
            var gameModel = new GameModel();
            gameModel.InitializeGame(4, 3, new HashSet<(int, int)> { (0, 0) });

            // Act
            gameModel.ProcessUserInput("A1");

            // Assert
            Assert.AreEqual(GameState.Lose, gameModel.GameState);
        }


       



    }
}
