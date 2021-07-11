using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Library
{
    public interface IUpdateHandler
    {
        Task HandleUpdate(ITelegramBotClient botClient, Update update);
    }
}