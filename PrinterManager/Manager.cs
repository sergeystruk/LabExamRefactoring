using System;
using System.Collections.Generic;
using Logger.Interface;

namespace PrinterManager
{
    public class Manager
    {
        private HashSet<Printer.Abstract.Printer> set;
        private ILogger logger;

        public Manager(ILogger logger)
        {
            this.logger = logger;
            set = new HashSet<Printer.Abstract.Printer>();
        }

        public Manager() { }

        public void Add(Printer.Abstract.Printer printer)
        {
            if(ReferenceEquals(set, null))
            {
                set = new HashSet<Printer.Abstract.Printer>();
            }

            if (ReferenceEquals(printer, null))
            {
                throw new ArgumentNullException(nameof(printer));
            }

            set.Add(printer);
        }

        public bool Remove(Printer.Abstract.Printer printer)
        {
            if(ReferenceEquals(set, null))
            {
                return true;
            }

            if (ReferenceEquals(printer, null))
            {
                return true;
            }

            if(set.Contains(printer))
            {
                set.Remove(printer);
                return true;
            }

            return false;
        }

        public string Print()
        {
            return null;
        }
    }
}
