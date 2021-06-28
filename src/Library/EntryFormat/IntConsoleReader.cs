using System;

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