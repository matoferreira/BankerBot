using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Library
{
    public class UpdateHandler : IUpdateHandler
    {
        readonly Func<ITelegramBotClient, Update, Task> _updateHandler;
        public UpdateHandler(Func<ITelegramBotClient, Update, Task> updateHandler)
        {
            _updateHandler = updateHandler;
        }
        public Task HandleUpdate(ITelegramBotClient botClient, Update update) =>
            _updateHandler(botClient, update);

    }
}