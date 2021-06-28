using System;

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