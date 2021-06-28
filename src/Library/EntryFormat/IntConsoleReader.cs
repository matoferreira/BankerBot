using System;
// IntconsoleReader se encarga de recibir un int de la consola, para que el usuario pueda interactuar con el menú del bot.
//Es una implementación de una interface, porque más adelante agregaremos más maneras de interactuar con el usuario
//Ej. Telegram. Al utilizar una interfase, será posible agregarlo sin cambiar el código del bot 
//(Pues el core bot depende de una abstraccíon y no de el consoleReader)
namespace Library
{
    public class IntConsoleReader : IIntInput
    {
        public int GetInput(string message)
        {
            int n;
            string input;
            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
            } while (int.TryParse(input, out n) == false);
            return n;
        }
    }
}