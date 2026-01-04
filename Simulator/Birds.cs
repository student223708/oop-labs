using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator
{
    public class Birds : Animals
    {
        private bool canfly = true;
        public bool CanFly
        {
            get => canfly;
        }

        public override string ToString() => Info;

        public override string Info => $"{(GetType().Name).ToUpper()}: {Description} {Validator.Fly(canfly)} <{Size}>";

    }
}
