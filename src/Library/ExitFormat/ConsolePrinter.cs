using System;
//ConsolePrinter se encarga de imprimir en la consola el comportamiento del bot que debe ver el usuario.
//Al ser una implementación de una interface, es posible agregar más plataformas en el futuro, ya que
//no dependerá de la clase sino de una abstracción (DIP). De esta manera podemos estar abiertos a ala extensión.
//Recibe un string y le da formato para luego imprimirlo en la consola.
namespace Library
{
    public class ConsolePrinter : IExitFormat
    {
        public string PrintLine(string line)
        {
            //return "No usado";
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
            return "No usado";
        }
    }
}