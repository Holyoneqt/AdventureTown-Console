using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spielwiese.Util.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CommandAttribute : Attribute
    {
        public CommandAttribute() : this("")
        {
        }

        public CommandAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
