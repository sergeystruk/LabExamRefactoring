using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Interface;

namespace Logger.Concrete
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string str)
        {
            Console.WriteLine(str);
        }
    }
}
