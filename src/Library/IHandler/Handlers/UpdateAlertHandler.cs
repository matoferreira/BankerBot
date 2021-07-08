using System;

namespace Library
{
    public class UpdateAlertHandler : AbstractHandler
    {
        public override void Handle(Request request)
        {
            if (request.Content == "/actualizaralerta")
            {
                
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}