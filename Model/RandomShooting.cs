using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class RandomShooting : INextTarget
    {
        public RandomShooting(Grid targetGrid, int shipLenght)
        {
            this.targetGrid = targetGrid;
            this.shipLenght = shipLenght;
        }

        private Grid targetGrid;
        private int shipLenght;
        private Random random = new Random();

        public Square NextTarget()
        {
            var placements = targetGrid.GetAvailablePlacments(shipLenght);
            // TODO: filter square that appears most times
            var candidates = placements.SelectMany(s => s);
            var index = random.Next(candidates.Count());
            return candidates.ElementAt(index);
        }
    }
}
