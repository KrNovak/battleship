using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.Oom.Battleship.Model;
using System.Linq;
using System.Collections.Generic;

namespace Vsite.Oom.Battleship.UnitTests
{
    [TestClass]
    public class TestFleet
    {
        [TestMethod]
        public void CreateShipAddsNewShipToFleet()
        {
            var fleet = new Fleet();
            Assert.AreEqual(0, fleet.Ships.Count());

            fleet.CreateShip(new List<Square> { new Square(2, 3), new Square(3, 3), new Square(4, 3) });
            Assert.AreEqual(1, fleet.Ships.Count());

            fleet.CreateShip(new List<Square> { new Square(5, 3), new Square(5, 4), new Square(5, 5) });
            Assert.AreEqual(2, fleet.Ships.Count());
        }
    }
}
