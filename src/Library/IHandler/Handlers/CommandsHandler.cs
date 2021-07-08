using System;

namespace Library
{
    public class CommandsHandler : AbstractHandler
    {
        public IStringInput StringImput = Singleton<ConsoleReader>.Instance;
        public override void Handle(Request request)
        {
            if (request.Content == "/Comandos")
            {
                //Mostrar listado de comandos
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}