using Spielwiese.Functions.Counter;
using Spielwiese.Util.Attributes;
using Spielwiese.Util.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Spielwiese.Util.Helper
{
    public class CommandParser
    {
        private object _class;

        private List<MethodInfo> _methods;

        public CommandParser(object o)
        {
            _class = o;
            _methods = _class.GetType()
                                .GetMethods()
                                .Where(m => m.GetCustomAttributes(typeof(CommandAttribute), true).Length > 0)
                                .ToList();
        }

        public void CallMethod(string input)
        {
            string cmd;
            string[] parameters;

            int cmdEndPos = input.IndexOf(':');
            if (cmdEndPos == -1)
            {
                cmd = input;
                parameters = new string[0];
            }
            else
            {
                cmd = input.Substring(0, cmdEndPos);
                parameters = input.Substring(cmdEndPos + 1).Split(',');
            }

            Invoke(cmd, parameters);
        }

        private void Invoke(string cmd, string[] parameters)
        {
            MethodInfo method = _methods.Where(m => m.GetCustomAttribute<CommandAttribute>().Name.Equals(cmd)).FirstOrDefault();
            if(method == null)
            {
                throw new CommandException($"Command '{cmd}' not recognized!");
            }

            if(parameters.Length != method.GetParameters().Length)
            {
                Console.WriteLine($"Please provide {method.GetParameters().Length} Parameters! (You provided {parameters.Length})");
                return;
            }

            method.Invoke(_class, parameters);

        }

    }
}
