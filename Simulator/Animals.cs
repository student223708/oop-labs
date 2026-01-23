using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator
{
    public class Animals
    {
        private string description = "Unknown";
        public required string Description
        {
            get => description;
            init => description = Validator.Shortener(value, 3, 15, '#');

        }
        public uint Size { get; set; } = 3;

        public Map? map;

        private Point position;
        public Point Position
        {
            get => position;
            set => position = value;
        }

        public void Spawn(Point position, Map map)
        {
            if (map.Exist(position))
            {
                Position = position;
                this.map = map;
            }
        }

        public void Go(Direction direction)
        {
            if (map == null) throw new ArgumentNullException("This Creature is not deployed");
            else Position = map.Next(position, direction);
        }

        public void Despawn()
        {
            this.map = null;
        }

        public override string ToString() => $"{(GetType().Name).ToUpper()}: {description} <{Size}>";

        public virtual string Info
        {
            get;
        }

        public Animals()
        {

        }

    }
}