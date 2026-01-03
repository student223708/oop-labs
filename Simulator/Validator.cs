using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simulator
{ 
         public static class Validator
         {
            public static int Limiter(int value, int min, int max)
            {
                if (value <= min) return min;
                else if (value > max) return max;
                else return value;
            }

            public static string Shortener(string value, int min, int max, char placeholder)
            {
                value = Regex.Replace(value, " +", " ");
                value = value.Trim();

                if (value.Length < min)
                    value = value.PadRight(min, placeholder);

                if (value.Length > max)
                    value = value.Remove(max, value.Length - max);

                value = value.Trim();
                value = char.ToUpper(value[0]) + value.Substring(1);
                return value;
            }
         }
}
