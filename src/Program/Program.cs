using System;
using Library;

namespace Program
{
    class Program
    {
        private string linea;
        private ConsolePrinter Printer;
        static void Main(string[] args)
        {
            //UserInterface Interface = Singleton<UserInterface>.Instance;
            
        
            string linea = "Juan hols#Hola#jjj   gtgd##";
            ConsolePrinter Printer = new ConsolePrinter();
            Printer.PrintLine(linea);
        }
    }
}
