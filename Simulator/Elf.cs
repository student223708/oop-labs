using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Elf : Creature
    {
        private int agility;
        public int Agility
        {
            get => agility;
            init => agility = Validator.Limiter(value, 0, 10);
        }

        private int stacks = 0;

        public override string Info => $"{(GetType().Name).ToUpper()}: {Name} [{Level}]";
        public override string ToString() => $"{Info} [{agility}]";

        public void Sing()
        {
            stacks++;
            if ((stacks == 3) && (agility < 10)) { agility++; stacks = 0; }
        }

        public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";

        public override int Power => 8 * Level + 2 * agility;

        public Elf(string name, int level = 1, int agility = 0) : base(name, level)
        {
            Agility = agility;
        }
        public Elf()
        {

        }
    }
}
