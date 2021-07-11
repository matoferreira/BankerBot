using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot.Requests.Abstractions;
using System.Threading;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.Payments;

namespace Library
{
    public class TelegramClient
    {
        //Encapsular esto!!!!!
        public static Dictionary<double, UserProfile> Users = new Dictionary<double, UserProfile>();
        public static HandlersList ListOfHandlers = new HandlersList();
        //public IExitFormat Output = Singleton<TelegramPrinter>.Instance;
        public TelegramBot telegramBot = TelegramBot.Instance;

        public void Start()
        {
            Console.WriteLine($"Hola soy BankyBot, el bot de finanzas personales, mi nombre es {telegramBot.BotName} y tengo el Identificador {telegramBot.BotId}");

            //Obtengo el cliente de Telegram
            ITelegramBotClient bot = telegramBot.Client;

            //Asigno un gestor de mensajes
            bot.OnUpdate += OnUpdateReceived;

            //Inicio la escucha de mensajes
            bot.StartReceiving();


            Console.WriteLine("Presiona una tecla para terminar");
            Console.ReadKey();

            //Detengo la escucha de mensajes 
            bot.StopReceiving();



        }

        private async void OnUpdateReceived(object sender, UpdateEventArgs e)
        {
            int offset = 0;
            var updates = telegramBot.Client.GetUpdatesAsync(offset).Result;
            foreach (Update update in updates)
            {
                offset = update.Id + 1;
                Message message = e.Update.Message;
            Chat chatInfo = message.Chat;
            string messageText = message.Text.ToLower();
            if (messageText != null)
            {
                ITelegramBotClient client = TelegramBot.Instance.Client;
                if (Users.ContainsKey(message.Chat.Id) == false)
                {
                    Console.WriteLine($"{chatInfo.FirstName}: no existe {message.Text}");
                    Users.Add(message.Chat.Id, new UserProfile());
                }
                else
                {
                    Console.WriteLine($"{chatInfo.FirstName}: existe {message.Text}");
                }
                UserProfile PerfilUsuario;
                Users.TryGetValue(message.Chat.Id, out PerfilUsuario);
                Console.WriteLine($"{chatInfo.FirstName}: envío {message.Text}");
                await ListOfHandlers.newBankAccountHandler.Handle(new Request(e.Update, PerfilUsuario));
            
            }
            }
        }
        

        private static async void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            Message message = messageEventArgs.Message;
            Chat chatInfo = message.Chat;
            string messageText = message.Text.ToLower();
            if (messageText != null)
            {
                ITelegramBotClient client = TelegramBot.Instance.Client;
                if (Users.ContainsKey(message.Chat.Id) == false)
                {
                    Console.WriteLine($"{chatInfo.FirstName}: no existe {message.Text}");
                    Users.Add(message.Chat.Id, new UserProfile());
                }
                else
                {
                    Console.WriteLine($"{chatInfo.FirstName}: existe {message.Text}");
                }
                UserProfile PerfilUsuario;
                Users.TryGetValue(message.Chat.Id, out PerfilUsuario);
                Console.WriteLine($"{chatInfo.FirstName}: envío {message.Text}");
                //await ListOfHandlers.newBankAccountHandler.Handle(new Request(message, PerfilUsuario));
            }
        }
    }
}