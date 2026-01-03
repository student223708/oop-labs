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


       

        public void Upgrade()
        {
            if (level < 10)level++;
        }


        public string Info =>  $"{Name} [{Level}]"; 


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

    public class Elf : Creature
    {
        private int agility;
        public int Agility
        {
            get => agility;
            init => agility = Validator.Limiter(value, 0, 10);
        }

        private int stacks=0;
        public void Sing()
        {
            Console.WriteLine($"{Name} is singing.");

            stacks++;
            if ((stacks == 3) &&(agility < 10)) { agility++; stacks = 0; }
            
            
        }
        public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");

        public override int Power => 8 * Level + 2 * agility;

        public Elf(string name, int level = 1, int agility = 0) : base(name, level)
        {
            Agility = agility;
        }
        public Elf()
        {

        }
    }

    public class Orc : Creature
    {
        private int rage;
        public int Rage
        {
            get => rage;
            init => rage = Validator.Limiter(value, 0, 10);
        }

        private int stacks=0;
        public void Hunt()
        {
            Console.WriteLine($"{Name} is hunting.");
            stacks++;
            if ((stacks == 2) && (rage < 10)){ rage++; stacks = 0; }
        }

        public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");
        
        public override int Power => 7*Level+3*rage;


        public Orc(string name, int level = 1, int rage = 0) : base(name, level)
        {
            Rage = rage;
        }

        public Orc() 
        {

        }

    }



}
