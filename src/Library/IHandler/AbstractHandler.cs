using System;

namespace Library
{
    public class AbstractHandler : IHandler
    {
        public IHandler Next { get; set;}
        public TelegramPrinter Output { get; protected set;}
        public AbstractHandler()
        {
            this.Output = new TelegramPrinter();
        }
        public virtual void Handle(Request request)
        {
            if (this.Next != null)
            {
                this.Next.Handle(request);
            }
        }
    }
}