using System;
using System.Text;

namespace Library
{
    public class StartHandler : AbstractHandler
    {
        public override void Handle(Request request)
        {
            if (request.Content == "/start")
            {
                Output.PrintLine("Bienvenido al BankyBot, soy Banky y te voy a ayudar en tus finanzas personales, escribe /comandos para ver todo lo que puedo hacer");
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}