using System;

namespace Library
{
    public class AbstractHandler: IHandler
    {
        public IHandler Next { get; set; }

        public virtual void Handle(Request request)
        {
            if (this.Next != null)
            {
                this.Next.Handle(request);
            }
        }
    }
}