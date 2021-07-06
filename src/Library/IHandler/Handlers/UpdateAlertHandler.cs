using System;

namespace Library
{
    public class UpdateAlertHandler: AbstractHandler
    {
        public IStringInput StringImput = Singleton<ConsoleReader>.Instance;
        public override void Handle(Request request)
        {
            if (request.Content == "/ActualizarAlerta")
            {
                
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}