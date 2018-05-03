using System;

namespace PrinterManager
{
    public class ConsoleLogger : ILogger
    {
        public void Log(object source, LoggerEventArgs args)
        {
            Console.WriteLine(args.Message);
        }

        public void Register(Manager manager)
        {
            manager.PrintAction += Log;
        }

        public void Unregister(Manager manager)
        {
            manager.PrintAction -= Log;
        }
    }
}
