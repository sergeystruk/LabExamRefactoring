using System;

namespace Printer.Concrete
{
    public class CanonPrinter : Abstract.Printer
    {
        public CanonPrinter(string name, string model)
        {

            Name = name ?? throw new ArgumentNullException(nameof(name));
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }
    }
}
