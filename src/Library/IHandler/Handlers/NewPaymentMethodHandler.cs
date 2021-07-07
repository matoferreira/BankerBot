using System;

namespace Library
{
    public class NewPaymentMethodHandler : AbstractHandler
    {
        public IStringInput StringImput = Singleton<ConsoleReader>.Instance;
        public override void Handle(Request request)
        {
            if (request.Content == "/AgregarMetodoDePago")
            {
                
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}