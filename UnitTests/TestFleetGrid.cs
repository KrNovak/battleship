using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.Oom.Battleship.Model;

namespace Vsite.Oom.Battleship.UnitTests
{
    [TestClass]
    public class TestFleetGrid
    {
        [TestMethod]
        public void ConstructorForTenRowsAndTenColumnsCreatesGridWith80Squares()
        {
            var grid = new FleetGrid(10, 8);
            Assert.AreEqual(10, grid.Rows);
            Assert.AreEqual(8, grid.Columns);
            Assert.AreEqual(80, grid.Squares.Count());

            Assert.IsTrue(grid.Squares.Contains(new Square(0, 0)));
            Assert.IsTrue(grid.Squares.Contains(new Square(0, 7)));
            Assert.IsTrue(grid.Squares.Contains(new Square(9, 0)));
            Assert.IsTrue(grid.Squares.Contains(new Square(9, 7)));

            Assert.IsFalse(grid.Squares.Contains(new Square(10, 10)));

        }
        [TestMethod]
        public void GetAvailablePlacmentsReturns2PlcmentsForShip3SquaresLongOnGridWith1Row4Columns()
        {
            var grid = new FleetGrid(1,4);
            var placements = grid.GetAvailablePlacments(3);
            Assert.AreEqual(2, placements.Count());
        }    
        [TestMethod]
        public void GetAvailablePlacmentsReturns3PlcmentsForShip3SquaresLongOnGridWith5Row1Columns()
        {
            var grid = new FleetGrid(5,1);
            var placements = grid.GetAvailablePlacments(3);
            Assert.AreEqual(3, placements.Count());
        }
        [TestMethod]
        public void GetAvailablePlacmentsReturns3PlcmentsForShip2SquaresLongOnGridWith1Row6ColumnsEliminateSecondColumn()
        {
            var grid = new FleetGrid(1,6);
            grid.EliminateSquare(0, 2);
            var placements = grid.GetAvailablePlacments(2);
            Assert.AreEqual(3, placements.Count());
        }
        [TestMethod]
        public void GetAveliablePlacementsReturns2PlcementsForShip2SquaresLongOnGridWith5Row1ColumnsEliminateFirstRow()
        {
            var grid = new FleetGrid(5, 1);
            grid.EliminateSquare(1, 0);
            var placements = grid.GetAvailablePlacments(2);
            Assert.AreEqual(2, placements.Count());
        }

    }
}
