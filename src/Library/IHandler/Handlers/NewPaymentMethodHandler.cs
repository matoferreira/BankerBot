using System;

namespace Library
{
    public class NewPaymentMethodHandler : AbstractHandler
    {
        public override object Handle(Request request)
        {
            if (request.Content == "/agregarmetododepago")
            {
                return "falta implementar";
            }
            else
            {
                return base.Next.Handle(request);
            }
        }
    }
}