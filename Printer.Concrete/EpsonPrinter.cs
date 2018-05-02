using System;

namespace Printer.Concrete
{
    class EpsonPrinter : Abstract.Printer
    {
        public EpsonPrinter(string name, string model)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }
    }
}
