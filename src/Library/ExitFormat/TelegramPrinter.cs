using System;
//ConsolePrinter se encarga de imprimir en la consola el comportamiento del bot que debe ver el usuario.
//Al ser una implementación de una interface, es posible agregar más plataformas en el futuro, ya que
//no dependerá de la clase sino de una abstracción (DIP). De esta manera podemos estar abiertos a ala extensión.
//Recibe un string y le da formato para luego imprimirlo en la consola.
namespace Library
{
    public class TelegramPrinter : IExitFormat
    {
        public string PrintLine(string line)
        {
            return line;
        }
    }
}