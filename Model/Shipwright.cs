using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class Shipwright
    {
        public Shipwright(int rows, int columns, IEnumerable<int> shipLengths)
        {
            this.rows = rows;
            this.columns = columns;
            this.shipLengths = shipLengths;
        }

        private readonly int rows;
        private readonly int columns;
        private readonly IEnumerable<int> shipLengths;

        public Fleet CreateFleet()
        {
            for (int trying = 0; trying < 3; ++trying)
            {
                var grid = new FleetGrid(rows, columns);
                var fleet = new Fleet();
                var squareEliminator = new SquareEliminator(rows, columns);

                var rnd = new Random();
                foreach (int length in shipLengths)
                {
                    var available = grid.GetAvailablePlacments(length);
                    var index = rnd.Next(0, available.Count());
                    if (available.Count() == 0)
                        break;
                    var selected = available.ElementAt(index);
                    fleet.CreateShip(selected);
                    var toEliminate = squareEliminator.ToEliminate(selected);
                    foreach (var square in toEliminate)
                        grid.EliminateSquare(square.Row, square.Column);
                }

                return fleet;
            }

            throw new InvalidOperationException();
        }
    }
}
