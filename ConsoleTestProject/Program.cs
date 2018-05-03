using System;
using PrinterManager;
using Printer.Concrete;

namespace ConsoleTestProject
{
    class Program
    {
        private static Manager manager = new Manager(new LogToFile());

        [STAThread]
        static void Main(string[] args)
        {
            bool isWorking = true;
            do
            {
                Console.WriteLine("Select your choice:");
                Console.WriteLine("1:Add new Canon printer");
                Console.WriteLine("2:Add new Epson printer");
                Console.WriteLine("3:Watch the list of printers");
                Console.WriteLine("4:Print on all");
                Console.WriteLine("5:Exit");
                
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.D1)
                {
                    Console.WriteLine();
                    CreatePrinterCanon();
                }

                if (key.Key == ConsoleKey.D2)
                {
                    Console.WriteLine();
                    CreatePrinterEpson();
                }

                if (key.Key == ConsoleKey.D3)
                {
                    Console.WriteLine();
                    GetList();
                }

                if (key.Key == ConsoleKey.D4)
                {
                    Console.WriteLine();
                    Print();
                }

                if (key.Key == ConsoleKey.D5)
                {
                    isWorking = false;
                }

            } while (isWorking);
        }

        private static void Print()
        {
            manager.Print();
        }
        
        private static void CreatePrinterCanon()
        {
            Tuple<string, string> tuple = ReadingFromConsole();
            CanonPrinter canonPrinter = new CanonPrinter(tuple.Item1, tuple.Item2);
            manager.Add(canonPrinter);
        }

        private static void CreatePrinterEpson()
        {
            Tuple<string, string> tuple = ReadingFromConsole();
            EpsonPrinter epsonPrinter = new EpsonPrinter(tuple.Item1, tuple.Item2);
            manager.Add(epsonPrinter);
        }

        private static void GetList()
        {
            int i = 0;
            foreach (var item in manager.Set)
            {
                Console.WriteLine($"{i++}. {item.ToString()}");
            }
        }

        private static Tuple<string, string> ReadingFromConsole()
        {
            Console.WriteLine("Enter name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Enter model: ");
            var model = Console.ReadLine();

            return Tuple.Create(name, model);
        }
    }
}
