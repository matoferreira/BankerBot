using System;

namespace Library
{
    public class ConsolePrinter : IPrinter
    {
        public void PrintLine(string line)
        {
            string linea = "";
            int num = 0;
            while (line.Length >= num - 1)
            {
                do
                {
                    linea = linea + line[num];
                    num += 1;
                } while ((!line[num].Equals("#")) && (line.Length <= num + 1));
                Console.WriteLine($"{linea} \n");
                //num += 1;
            }
        }
    }
}