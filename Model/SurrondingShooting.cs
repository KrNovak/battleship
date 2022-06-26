using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    using SquareSequence = IEnumerable<Square>;
    public class SurrondingShooting : INextTarget
    {
        public SurrondingShooting(EnemyGrid grid, Square initialHit, int shipLenght )
        {
            this.grid = grid;
            this.initialHit = initialHit;
            this.shipLenght = shipLenght;
        }
        EnemyGrid grid;
        Square initialHit;
        int shipLenght;
        Random random= new Random();
        public Square NextTarget()
        {
            List<SquareSequence> sequances = new List<SquareSequence>();
            foreach(Direction direction in Enum.GetValues(typeof(Direction)))
            {
                var seq = grid.GetAvailableSquares(initialHit.Row, initialHit.Column, direction);
                if (seq.Count() > 0)
                {
                    sequances.Add(seq);
                }
            }
            int index = random.Next(sequances.Count());
            return sequances[index].First();
        }
    }
}
