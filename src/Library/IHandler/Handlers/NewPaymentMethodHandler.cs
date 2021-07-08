using System;

namespace Library
{
    public class NewPaymentMethodHandler : AbstractHandler
    {
        public override void Handle(Request request)
        {
            if (request.Content == "/agregarmetododepago")
            {
                
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}