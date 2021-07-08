using System;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            TelegramBot telegramBot = TelegramBot.Instance;
            Console.WriteLine($"Hola soy el Bot de P2, mi nombre es {telegramBot.BotName} y tengo el Identificador {telegramBot.BotId}");
            TelegramProgram teleProgram = new TelegramProgram();
            teleProgram.Run();
            //UserInterface Interface = Singleton<UserInterface>.Instance;
        }
    }
}
