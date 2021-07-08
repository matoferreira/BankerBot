using System;

namespace Library
{
    public class AddMovementHandler : AbstractHandler
    {
        public override void Handle(Request request)
        {
            if (request.Content == "/agregarmovimiento")
            {
                
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}