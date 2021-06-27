using System;

namespace Library
{
    public class ConsolePrinter : IExitFormat
    {
        public void PrintLine(string line)
        {
            string linea = "";
            int num = 0;
            while (num < line.Length)
            {
                if (line[num] == '#')
                {
                    Console.WriteLine($"{linea}");
                    linea = "";
                }
                else
                {
                    linea = linea + line[num];
                }
                if (num + 1 == line.Length && (!line[num].Equals("#")))
                {
                    linea = linea + line[num];
                    Console.WriteLine($"{linea}");
                    linea = "";
                }
                num += 1;
            }
        }
    }
}