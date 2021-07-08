using System;
using System.Text;

namespace Library
{
    public class StartHandler : AbstractHandler
    {
        public override object Handle(Request request)
        {
            if (request.Content == "/start")
            {
                return "Bienvenido al BankyBot, soy Banky y te voy a ayudar en tus finanzas personales, escribe /comandos para ver todo lo que puedo hacer";
            }
            else
            {
                return base.Next.Handle(request);
            }
            
        }
    }
}