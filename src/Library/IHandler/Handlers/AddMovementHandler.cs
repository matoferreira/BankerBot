using System;

namespace Library
{
    public class AddMovementHandler : AbstractHandler
    {
        public override object Handle(Request request)
        {
            if (request.Content == "/agregarmovimiento")
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