using System;

namespace Library
{
        public class ConsoleReader : IStringImput
    {
        public string GetImput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
            
        }
    }
}