using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
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

        public abstract int Power { get; }

        public abstract string Info { get; }

        public override string ToString() => $"{(GetType().Name).ToUpper()}: {name} [{level}]";

        public void Upgrade()
        {
            if (level < 10)level++;
        }

        public abstract string Greeting();

        public static string Slogan() => $"Creatures are great!";


        public string Go(Direction direction) => $"{direction.ToString().ToLower()}";

        public string[] Go(Direction[] directions)
        {

            string[] array = new string[directions.Length];
            int i = 0;

            foreach (Direction direction in directions)
            {
                array[i] = Go(direction);
                i++;
            }

            return array;
        }

        public string[] Go(string directions)
        {
            string[] array = new string[directions.Length];
            int i = 0;

            foreach (Direction direction in DirectionParser.Parse(directions))
            {
                array[i] = Go(direction);
                i++;
            }

            return array;
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