using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Numerics;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simulator
{
    public abstract class Creature
    {
        private string name = "Unknown";
        public string Name
        {
            get => name;
            init => name = Validator.Shortener(value, 3, 25, '#');
            
        }
        
        
        private int level;
        public int Level
        {
            get => level;
            init => level = Validator.Limiter(value,1,10);
        }

        public abstract int Power
        {
            get;
        }

        public abstract string Info
        {
            get;
        }

        public override string ToString() => $"{(GetType().Name).ToUpper()}: {name} [{level}]";

        public void Upgrade()
        {
            if (level < 10)level++;
        }

        public abstract void SayHi();

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

        public Creature() 
        {

        }

    }
    

}