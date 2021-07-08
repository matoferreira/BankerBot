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
        public virtual object Handle(Request request)
        {
            if (this.Next != null)
            {
                return this.Next.Handle(request);
            }
            else
            {
                return "Error en cad Abstrac";
            }
        }
    }
}