using System;
using Telegram.Bot.Types;

namespace Library
{
    public class Request
    {
        public Update Content { get; set; }
        public UserProfile Profile;

        public Request(Update content, UserProfile profile)
        {
            this.Content = content;
            this.Profile = profile;
        }
    }
}