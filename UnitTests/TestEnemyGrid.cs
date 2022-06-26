using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.Oom.Battleship.Model;

namespace Vsite.Oom.Battleship.UnitTests
{
    [TestClass]
    public class TestEnemyGrid
    {
        [TestMethod]
        public void GetAvailableSquaresReturns3SquaresLeftFromSquare3_3OnGrid10x10()
        {
            var grid = new EnemyGrid(10, 10);
            var result = grid.GetAvailableSquares(3, 3, Direction.Leftwards);
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual(new Square(3, 2), result.ElementAt(0));
        }
        [TestMethod]
        public void GetAvailableSquaresReturns1SquaresLeftFromSquare3_3OnGrid10x10IfSquare3_1IsEliminated()
        {
            var grid = new EnemyGrid(10, 10);
            grid.ChangeSquareState(3, 1, SquareState.Missed);
            var result = grid.GetAvailableSquares(3, 3, Direction.Leftwards);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(new Square(3, 2), result.ElementAt(0));
        }
        [TestMethod]
        public void GetAvailableSquaresReturns6SquaresRightFromSquare3_3OnGrid10x10()
        {
            var grid = new EnemyGrid(10, 10);
            var result = grid.GetAvailableSquares(3, 3, Direction.Rightwards);
            Assert.AreEqual(6, result.Count());
            Assert.AreEqual(new Square(3, 4), result.ElementAt(0));
        }
        [TestMethod]
        public void GetAvailableSquaresReturns3SquaresAboveFromSquare3_3OnGrid10x10()
        {
            var grid = new EnemyGrid(10, 10);
            var result = grid.GetAvailableSquares(3, 3, Direction.Upwards);
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual(new Square(2, 3), result.ElementAt(0));
        }
    }
}
