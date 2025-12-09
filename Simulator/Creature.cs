using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Creature
    {
        public string Name { get; } = "John";
        private int level { get; set; } = 1;
        public int Level
        {
            get => level;
            set => level = value > 0 ? value : 1;
        }

        public string Info =>  $"{Name} [{level}]"; 

        public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {level}.");

        public static void Slogan()
        {
            Console.WriteLine("Creatures are great!");
        }

        public Creature(string name, int level)
        {
            this.Name = name;
            this.Level = level;
        }

        public Creature() { }

    }
}
