using System;

namespace Printer.Abstract
{
    public abstract class Printer
    {
        public string Name { get; set; }
        public string Model { get; set; }

        public override bool Equals(object obj)
        {
            if(ReferenceEquals(obj, null))
            {
                return false;
            }

            var temp = obj as Printer;
            if(temp == null)
            {
                return false;
            }

            return Equals(temp);
        }

        public bool Equals(Printer printer)
        {
            if (ReferenceEquals(printer, null))
            {
                return false;
            }

            if(ReferenceEquals(this, printer))
            {
                return true;
            }

            return (Name == printer.Name) && (Model == printer.Model);
        }
    }
}
