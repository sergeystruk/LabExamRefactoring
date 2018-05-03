using System;
using System.IO;

namespace Printer.Abstract
{
    public abstract class Printer
    {
        #region Fields and properties
        public string Name { get; set; }
        public string Model { get; set; }
        #endregion

        #region Overrided methods
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

        public override int GetHashCode()
        {
            int result = 0;
            char[] type = GetType().Name.ToString().ToCharArray();
            for (int i = 0; i < type.Length; i++)
            {
                result += type[i];
            }

            char[] name = Name.ToCharArray();
            for (int i = 0; i < name.Length; i++)
            {
                result += name[i];
            }

            char[] model = Model.ToCharArray();
            for (int i = 0; i < model.Length; i++)
            {
                result += model[i];
            }

            return result;
        }

        public override string ToString()
        {
            return $"{GetType().Name}\t{Name}\t{Model}";
        }
        #endregion

        #region API
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

        public void Print(FileStream fileStream)
        {
            fileStream.Position = 3;
            for (int i = 3; i < fileStream.Length; i++)
            {
                Console.Write(Convert.ToChar(fileStream.ReadByte()));
            }

            Console.WriteLine();
        }
        #endregion
    }
}
