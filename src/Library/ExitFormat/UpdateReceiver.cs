using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;

namespace Library
{
    public class UpdateReceiver
    {
        static readonly Update[] EmptyUpdates = Array.Empty<Update>();

        readonly ITelegramBotClient botClient;
        public UpdateReceiver(
            ITelegramBotClient botClient)
        {
            this.botClient = botClient;
        }
        public async Task ReceiveAsync(IUpdateHandler updateHandler)
        {
            if (updateHandler is null) 
            { 
                Console.WriteLine("Handler vacio");
            }
            var emptyUpdates = EmptyUpdates;
                var timeout = (int) botClient.Timeout.TotalSeconds;
                var updates = emptyUpdates;
                try
                {
                   var request = new GetUpdatesRequest(){Timeout = timeout}; 
                   updates = await botClient.MakeRequestAsync(request).ConfigureAwait(false);
                }
                finally
                {
                    
                }

                foreach (var update in updates)
                {
                    try
                    {
                        await updateHandler.HandleUpdate(botClient, update).ConfigureAwait(false);
                    }
                    finally
                    {
                        
                    }
            }
        }
    }
}