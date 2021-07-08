using System;

namespace Library
{
    public class UpdateAlertHandler : AbstractHandler
    {
        public override object Handle(Request request)
        {
            if (request.Content == "/actualizaralerta")
            {
                return "Falta implementar";
            }
            else
            {
                return base.Next.Handle(request);
            }
        }
    }
}