using System;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            //TelegramBot telegramBot = TelegramBot.Instance;
            TelegramClient teleProgram = new TelegramClient();
            teleProgram.Start();
            //UserInterface Interface = Singleton<UserInterface>.Instance;
        }
    }
}
