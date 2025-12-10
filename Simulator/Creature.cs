using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simulator
{
    public class Creature
    {
        private string name = "Unknown";
        public string Name
        {
            get => name;
            init
            {
                name = value;
                name = Regex.Replace(name, " +", " ");
                name = name.Trim();

                if (name.Length < 3)
                    name = name.PadRight(3, '#');

                if (name.Length > 25)
                    name = name.Remove(25, name.Length - 25);

                name = name.Trim();
                name = char.ToUpper(name[0]) + name.Substring(1);
            }
        }
        
        
        private int level;
        public int Level
        {
            get => level;
            init
            {
                if (value <= 0) level = 1;
                else if (value > 10) level = 10;
                else level = value;
            }
        }

        public void Upgrade()
        {
            if (level < 10)level++;
        }


        public string Info =>  $"{Name} [{Level}]"; 


        public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");


        public static void Slogan()
        {
            Console.WriteLine("Creatures are great!");
        }

        public void Go(Direction direction)
        {
           
            switch ((int)direction){
                case 0: Console.WriteLine($"{Name} goes up.");break;
                case 1: Console.WriteLine($"{Name} goes right."); break;
                case 2: Console.WriteLine($"{Name} goes down."); break;
                case 3: Console.WriteLine($"{Name} goes left."); break;
            }
         }

        public void Go(Direction[] directions)
        {
            foreach (Direction direction in directions) Go(direction);
        }

        public void Go(string directions)
        {
            foreach (Direction direction in DirectionParser.Parse(directions)) Go(direction);
        }

        public Creature(string name, int level = 1)
        {
            this.Name = name;
            this.Level = level;
        }

        public Creature() { }

    }
}
