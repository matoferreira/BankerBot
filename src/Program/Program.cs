using System;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            //TelegramBot telegramBot = TelegramBot.Instance;
            TelegramProgram teleProgram = new TelegramProgram();
            teleProgram.Run();
            //UserInterface Interface = Singleton<UserInterface>.Instance;
        }
    }
}
