using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    /// <summary>
    /// Map of points.
    /// </summary>
    public abstract class Map
    {
        /// <summary>
        /// Check if give point belongs to the map.
        /// </summary>
        /// <param name="p">Point to check.</param>
        /// <returns></returns>
        public abstract bool Exist(Point p);

        /// <summary>
        /// Next position to the point in a given direction.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
        public abstract Point Next(Point p, Direction d);

        /// <summary>
        /// Next diagonal position to the point in a given direction
        /// rotated 45 degrees clockwise.
        /// </summary>
        /// <param name="p">Starting point.</param>
        /// <param name="d">Direction.</param>
        /// <returns>Next point.</returns>
        public abstract Point NextDiagonal(Point p, Direction d);
    }

    public class SmallSquareMap : Map
    {
        public readonly int Size;

        public Rectangle Square;

        public override bool Exist(Point p) => Square.Contains(p);

        public override Point Next(Point p, Direction d)
        {
            if (Exist(p.Next(d))) return p.Next(d);
            else return p;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            if (Exist(p.NextDiagonal(d))) return p.NextDiagonal(d);
            else return p;
        }

        public SmallSquareMap(int size) 
        {
            if (size < 5 || size > 20) throw new ArgumentOutOfRangeException("Invalid Map Size");
            else
            {
                Size = size;
                Square = new(0,0, size - 1, size - 1);

            }
        }
    }
}
