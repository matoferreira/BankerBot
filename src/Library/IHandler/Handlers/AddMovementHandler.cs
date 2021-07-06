using System;

namespace Library
{
    public class AddMovementHandler: AbstractHandler
    {
        public IStringInput StringImput = Singleton<ConsoleReader>.Instance;
        public override void Handle(Request request)
        {
            if (request.Content == "/AgregarMovimiento")
            {
                
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}