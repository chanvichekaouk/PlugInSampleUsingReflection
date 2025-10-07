using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlugIn
{
    public class Greeting
    {
        public string Greet(string name)
        {
            return $"Hello {name}! It is nice meeting you. This message is sent from the PlugIn...";
        }
    }
}
