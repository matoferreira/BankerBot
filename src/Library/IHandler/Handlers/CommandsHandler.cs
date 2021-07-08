using System;
using System.Text;

namespace Library
{
    public class CommandsHandler : AbstractHandler
    {
        public override void Handle(Request request)
        {
            if (request.Content == "/comandos")
            {
                StringBuilder commandsStringBuilder = new StringBuilder("Lista de Comandos:\n")
                                                                            .Append("/comandos\n")
                                                                            .Append("/estado\n")
                                                                            .Append("/agregarmetododepago\n")
                                                                            .Append("/agregarcuentabancaria\n")
                                                                            .Append("/agregartarjeta\n")
                                                                            .Append("/agregarbilletera\n")
                                                                            .Append("/actualizaralerta\n")
                                                                            .Append("/alertadeahorros\n")
                                                                            .Append("/alertabajosfondos\n")
                                                                            .Append("/alertagastosmensuales\n")
                                                                            .Append("/mostrarahorros\n")
                                                                            .Append("/mostrargastos\n")
                                                                            .Append("/agregarmovimiento\n")
                                                                            .Append("/agregaringreso\n")
                                                                            .Append("/agregargasto\n")
                                                                            .Append("/agregartransferenciainterna\n");
            

            Output.PrintLine(commandsStringBuilder.ToString());
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}