using System.IO;

namespace PrinterManager
{
    public class LogToFile : ILogger
    {
        public void Log(object source, LoggerEventArgs args)
        {
            using (var writer = File.AppendText("log.txt"))
            {
                writer.WriteLine($"{args.Message}");
            }
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
