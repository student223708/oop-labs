using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public static class DirectionParser
    {
        public static Direction[] Parse(string directions)
       { 
            Direction[] parsedDirections = new Direction[directions.Length];
            int i = 0;
            foreach (char Letter in directions)
            {

                switch (Letter)
                {
                    case 'U':
                    case 'u': parsedDirections[i] = Direction.Up; i++; break;

                    case 'R':
                    case 'r': parsedDirections[i] = Direction.Right; i++; break;

                    case 'D':
                    case 'd': parsedDirections[i] = Direction.Down; i++; break;

                    case 'L':
                    case 'l': parsedDirections[i] = Direction.Left; i++; break;

                }
            }

            Array.Resize(ref parsedDirections, i);
            return parsedDirections;
        }
    }
}
