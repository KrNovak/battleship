using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    using SquareSequence = IEnumerable<Square>;
    public class InlineShooting : INextTarget
    {
        public InlineShooting(EnemyGrid grid, List<Square> squaresHit, int shipLenght)
        {
            this.grid = grid;
            this.squaresHit = squaresHit;
            this.shipLenght = shipLenght;
        }
        EnemyGrid grid;
        List<Square> squaresHit;
        int shipLenght;
        Random random = new Random();

        public Square NextTarget()
        {
            squaresHit.Sort((s1, s2) => s1.Row + s1.Column - s2.Row - s2.Column);
            var first = squaresHit.First();
            var last = squaresHit.Last();
            List<SquareSequence> sequances = new List<SquareSequence>();
            if (first.Row == last.Row)
            {
                var right = grid.GetAvailableSquares(last.Row, last.Column, Direction.Rightwards);
                if (right.Count() > 0)
                {
                    sequances.Add(right);
                }
                var left = grid.GetAvailableSquares(first.Row, first.Column, Direction.Leftwards);
                if (left.Count() > 0)
                {
                    sequances.Add(left);
                }
            }
            else
            {
                var up = grid.GetAvailableSquares(first.Row, first.Column, Direction.Upwards);
                if (up.Count() > 0)
                {
                    sequances.Add(up);
                }

                var down = grid.GetAvailableSquares(last.Row, last.Column, Direction.Downwards);
                if (down.Count() > 0)
                {
                    sequances.Add(down);
                }
            }


            int index = random.Next(sequances.Count());
            return sequances[index].First();
            throw new NotImplementedException();
        }
    }
}
