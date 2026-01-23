using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class SmallTorusMap : Map
    {
        public override bool Exist(Point p) => Square.Contains(p);

        public override Point Next(Point p, Direction d)
        {
            if (Exist(p.Next(d))) return p.Next(d);
            else
            {
                switch (d)
                {
                    case Direction.Up: return new Point(p.X, 0);
                    case Direction.Right: return new Point(0, p.Y);
                    case Direction.Down: return new Point(p.X, Square.Y2);
                    case Direction.Left: return new Point(Square.X2, p.Y);
                    default: return p;
                }
            }
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            if (Exist(p.NextDiagonal(d))) return p.NextDiagonal(d);
            else
            {
                switch (d)
                {
                    case Direction.Up:
                        {
                            if (p.X == Square.X2 - 1 && p.Y == Square.Y2) return p = new(0, 0);
                            if (p.X == Square.X2 - 1) return p = new(0, p.Y + 1);
                            if (p.Y == Square.Y2) return p = new(p.X + 1, 0);
                            return p;
                        }
                    case Direction.Right:
                        {
                            if (p.X == Square.X2 - 1 && p.Y == 0) return p = new(0, Square.Y2);
                            if (p.X == Square.X2 - 1) return p = new(0, p.Y - 1);
                            if (p.Y == 0) return p = new(p.X + 1, Square.Y2);
                            return p;
                        }
                    case Direction.Down:
                        {
                            if (p.X == 0 && p.Y == 0) return p = new(Square.X2, Square.Y2);
                            if (p.X == 0) return p = new(Square.X2, p.Y - 1);
                            if (p.Y == 0) return p = new(p.X - 1, Square.Y2);
                            return p;
                        }
                    case Direction.Left:
                        {
                            if (p.X == 0 && p.Y == Square.Y2) return p = new(Square.X2, 0);
                            if (p.X == 0) return p = new(Square.X2, p.Y + 1);
                            if (p.Y == Square.Y2) return p = new(p.X - 1, 0);
                            return p;
                        }
                    default: return p;
                }
            }


        }
        public SmallTorusMap(int SizeX, int SizeY) : base(SizeX, SizeY)
        {
            if (Square.X2 + 1 > 20 || Square.Y2 + 1 > 20) throw new ArgumentOutOfRangeException("Invalid Map Size");
            else Square = new(0, 0, SizeX - 1, SizeY - 1);
        }

        public SmallTorusMap(int Size) : this(Size, Size) { }
    }
}
