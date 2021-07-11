using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Requests;
using System.Collections.Concurrent;

namespace Library
{
    public class NewBankAccountHandler : AbstractHandler
    {
        private string name;
        private static ITelegramBotClient client = TelegramBot.Instance.Client;
        static readonly ConcurrentDictionary<int, string[]> Answers = new ConcurrentDictionary<int, string[]>();
        public async override Task Handle(Request request)
        {
            if (request.Content.Message.Text == "/agregarcuentabancaria")
            {
                //var updates = client.GetUpdatesAsync().
                //string name;
                client.OnMessage += Bot_OnMessage;
                await client.SendTextMessageAsync(chatId: request.Content.Message.Chat.Id, text: "Ingrese el nombre del banco:", replyToMessageId: request.Content.Message.MessageId);
                name = client.GetUpdatesAsync((client.MessageOffset)).ToString();
                InlineKeyboardMarkup rkm = new InlineKeyboardMarkup(
                    new InlineKeyboardButton[][]
                    {
                        new InlineKeyboardButton[] 
                        {
                            InlineKeyboardButton.WithCallbackData( 
                            "Pesos", 
                            "pesos" 
                            ),
                            InlineKeyboardButton.WithCallbackData( 
                            "Dolares", 
                            "USD" 
                            )
                        }
                    }
                );
                await client.SendTextMessageAsync(chatId: request.Content.Message.Chat.Id, text: "Seleccione la Moneda:");
                //client.OnMessage += Bot_OnMessageReceived;
                Console.WriteLine("Exito");
                /*string moneda = StringImput.GetInput("Ingrese la moneda:");

                Currency currency = new Currency(moneda);
                BankAccount newAccount = new BankAccount(name, currency);
                
                int balance = Convert.ToInt32(StringImput.GetInput("Ingrese el saldo de la cuenta:"));
                newAccount.CurrentStatement.ChangeBalance(balance);
            
                request.Profile.AddPaymentMethod(newAccount);
                */
                //return "Medio de pago agregado con éxito.";
            }
            else
            {
                //return base.Next.Handle(request);
            }
        }

        private static void Bot_OnUpdateReceived(object sender, UpdateEventArgs e)
        {
            Console.WriteLine(e.Update.Message.Text);
            e.Update.Id = e.Update.Id + 1;
            //return e.Update.Message.Text;
        }
        private static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            Message message = e.Message;
            int userId = message.From.Id;

            if (message.Type == MessageType.Text)
            {
                if (Answers.TryGetValue(userId, out string[] answers))
                {
                    if (answers[0] == null)
                    {
                        answers[0] = message.Text;
                        await client.SendTextMessageAsync(message.Chat, "Now send me your age");
                    }
                    else if (answers[1] == null)
                    {
                        answers[1] = message.Text;
                        await client.SendTextMessageAsync(message.Chat, "Now send me your message");
                    }
                    else
                    {
                        Answers.TryRemove(userId, out string[] _);
                        await client.SendTextMessageAsync(message.Chat, "Thank you, that's all I need from you");

                        string answersText = $"User {answers[0]}, aged {answers[1]} sent the following message:\n{message.Text}";
                        await client.SendTextMessageAsync(e.Message.Chat.Id, answersText);
                    }
                }
                else
                {
                    Answers.TryAdd(userId, new string[2]);
                    await client.SendTextMessageAsync(message.Chat, "Please send me your name");
                }
            }
        }
    }
}