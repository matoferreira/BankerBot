using System;
//ConsoleReader es una implementación de la interfase IStringImput para interactuar con el usuario a través de la
//consola. Cumple con DIP pues la comunicación es a través de clases de alto nivel y abstracciones (Interfases).
//Cumple SRP pues su unica razon de cambio es recibir una linea de la consola. 
namespace Library
{
    public class ConsoleReader : IStringInput
    {
        public string GetInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();

        }
    }
}