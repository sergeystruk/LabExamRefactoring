using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PrinterManager
{
    public class Manager
    {
        public HashSet<Printer.Abstract.Printer> Set { get; private set; }
        private ILogger logger;
        public event EventHandler<LoggerEventArgs> PrintAction = delegate (object source, LoggerEventArgs args) { };

        public Manager(ILogger logger)
        {
            this.logger = logger;
            Set = new HashSet<Printer.Abstract.Printer>();
            this.logger.Register(this);
        }

        public Manager() : this(new ConsoleLogger()) { }

        public void Add(Printer.Abstract.Printer printer)
        {
            if(ReferenceEquals(Set, null))
            {
                Set = new HashSet<Printer.Abstract.Printer>();
            }

            if (ReferenceEquals(printer, null))
            {
                throw new ArgumentNullException(nameof(printer));
            }

            Set.Add(printer);
        }

        public bool Remove(Printer.Abstract.Printer printer)
        {
            if(ReferenceEquals(Set, null))
            {
                return true;
            }

            if (ReferenceEquals(printer, null))
            {
                return true;
            }

            if(Set.Contains(printer))
            {
                Set.Remove(printer);
                return true;
            }

            return false;
        }

        public void Print()
        {
            using (var o = new OpenFileDialog())
            {
                o.ShowDialog();
                using (var f = File.OpenRead(o.FileName))
                {
                    foreach (var item in Set)
                    {
                        OnPrintAction(this, new LoggerEventArgs($"{item.Name} {item.Model} start printing"));
                        item.Print(f);
                        OnPrintAction(this, new LoggerEventArgs($"{item.Name} {item.Model} ended printing"));
                    }
                }
            }
        }

        protected virtual void OnPrintAction(object source, LoggerEventArgs args)
        {
            PrintAction(source, args);
        }
        
    }
}
