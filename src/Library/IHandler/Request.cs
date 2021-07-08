using System;

namespace Library
{
    public class Request
    {
        public string Content { get; set; }
        public UserProfile Profile;

        public Request(string content, UserProfile profile)
        {
            this.Content = content;
            this.Profile = profile;
        }
    }
}