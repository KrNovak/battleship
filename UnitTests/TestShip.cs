using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.Oom.Battleship.Model;
using System.Linq;
using System.Collections.Generic;

namespace Vsite.Oom.Battleship.UnitTests
{
    [TestClass]
    public class TestShip
    {
        [TestMethod]
        public void ConstructorCreatesShipWithSquaresProvided()
        {
            var ship = new Ship(new List<Square> { new Square(2, 3), new Square(3, 3), new Square(4, 3) });
            Assert.AreEqual(3, ship.Squares.Count());
            CollectionAssert.Contains(ship.Squares.ToArray(), new Square(2, 3));
            CollectionAssert.Contains(ship.Squares.ToArray(), new Square(3, 3));
            CollectionAssert.Contains(ship.Squares.ToArray(), new Square(4, 3));
        }

        [TestMethod]
        public void ShootReturnMissedIfShipDoesNotContainGvenSquare()
        {
            var ship = new Ship(new List<Square> { new Square(2, 3), new Square(3, 3), new Square(4, 3) });
            var result = ship.Shoot(0, 0);
            Assert.AreEqual(HitResult.Missed, result);
        }

        [TestMethod]
        public void ShootReturnHitIfShipContainsGivenSquare()
        {
            var ship = new Ship(new List<Square> { new Square(2, 3), new Square(3, 3), new Square(4, 3) });
            var result = ship.Shoot(3, 3);
            Assert.AreEqual(HitResult.Hit, result);
        }

        [TestMethod]
        public void ShootReturnHitIfShipContainsAnotherGivenSquare()
        {
            var ship = new Ship(new List<Square> { new Square(2, 3), new Square(3, 3), new Square(4, 3) });
            var result = ship.Shoot(3, 3);
            result = ship.Shoot(4, 3);
            Assert.AreEqual(HitResult.Hit, result);
        }


        [TestMethod]
        public void ShootReturnSunkenforTheLastSqaureInTheShip()
        {
            var ship = new Ship(new List<Square> { new Square(2, 3), new Square(3, 3), new Square(4, 3) });
            var result = ship.Shoot(3, 3);
            result = ship.Shoot(4, 3);
            result = ship.Shoot(2, 3);
            Assert.AreEqual(HitResult.Sunken, result);
        }

        [TestMethod]
        public void ShootReturnMissedIfShipDoesNotContainSecondSquare()
        {
            var ship = new Ship(new List<Square> { new Square(2, 3), new Square(3, 3), new Square(4, 3) });
            var result = ship.Shoot(3, 3);
            result = ship.Shoot(0, 0);
            Assert.AreEqual(HitResult.Missed, result);
        }

        [TestMethod]
        public void ShootReturnSunkenIfSquareBelongsToSHipAlreadySunken()
        {
            var ship = new Ship(new List<Square> { new Square(2, 3), new Square(3, 3), new Square(4, 3) });
            var result = ship.Shoot(3, 3);
            result = ship.Shoot(4, 3);
            result = ship.Shoot(2, 3);
            result = ship.Shoot(2, 3);
            Assert.AreEqual(HitResult.Sunken, result);
        }


        [TestMethod]
        public void ShootReturnHitIfSquareHitShotAgain()
        {
            var ship = new Ship(new List<Square> { new Square(2, 3), new Square(3, 3), new Square(4, 3) });
            var result = ship.Shoot(3, 3);
            result = ship.Shoot(4, 3);
            result = ship.Shoot(3, 3);
            Assert.AreEqual(HitResult.Hit, result);
        }


    }
}
