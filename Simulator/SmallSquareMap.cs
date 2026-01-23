using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class SmallSquareMap : Map
    {
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

        public SmallSquareMap(int size) : base(size, size)
        {
            if (Square.X2 + 1 > 20 || Square.Y2 + 1 > 20) throw new ArgumentOutOfRangeException("Invalid Map Size");
            else
            {
                Square = new(0, 0, size - 1, size - 1);
            }
        }
    }
}
