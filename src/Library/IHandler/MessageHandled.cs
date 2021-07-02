using System;

namespace Library
{
    public class Request
    {
        public string Content { get; set; }

        public string From { get; set; }

        public Request(string content)
        {
            this.Content = content;
        }
    }
}