using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTown.UI.Helper
{
    public class ConsoleKeyParser
    {
        public static int GetIntFromKey(ConsoleKeyInfo key)
        {
            if(int.TryParse(key.KeyChar.ToString(), out int val))
            {
                return val;
            }
            return -1;
        }
    }
}
