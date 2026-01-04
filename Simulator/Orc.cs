using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Orc : Creature
    {
        private int rage;
        public int Rage
        {
            get => rage;
            init => rage = Validator.Limiter(value, 0, 10);
        }

        private int stacks = 0;

        public override string Info => $"{(GetType().Name).ToUpper()}: {Name} [{Level}]";
        public override string ToString() => $"{Info} [{rage}]";

        public void Hunt()
        {
            Console.WriteLine($"{Name} is hunting.");
            stacks++;
            if ((stacks == 2) && (rage < 10)) { rage++; stacks = 0; }
        }

        public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");

        public override int Power => 7 * Level + 3 * rage;


        public Orc(string name, int level = 1, int rage = 0) : base(name, level)
        {
            Rage = rage;
        }

        public Orc()
        {

        }
    }
}
