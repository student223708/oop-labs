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

        public Map? map;
        
        private int level;
        public int Level
        {
            get => level;
            init => level = Validator.Limiter(value,1,10);
        }
        private Point position;
        public  Point Position
        {
            get => position;
            set => position = value;
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

        public void Spawn(Point position, Map map)
        {
            if (map.Exist(position))
            {
                Position = position;
                this.map = map;
            }
        }

        public void Despawn()
        {
            this.map = null;
        }

        public void Go(Direction direction)
        {
            if (map == null) throw new ArgumentNullException("This Creature is not deployed");
            if (map.Next(position ,direction).ToString == position.ToString) throw new ArgumentOutOfRangeException("Creature cannot move there");
            else
            {
                position = map.Next(position, direction);
                map.creaturesLocations[map.creatures.IndexOf(Name)] = position.ToString();
            }

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