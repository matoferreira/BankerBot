using System;

namespace Library
{
    public class AddInternalTransferHandler : AbstractHandler
    {
        public IStringInput StringImput = Singleton<ConsoleReader>.Instance;
        public IIntInput IntImput = Singleton<IntConsoleReader>.Instance;
        public override object Handle(Request request)
        {
            if (request.Content == "/agregartransferenciainterna")
            {
                bool movimiento;
                /// <summary>
                /// /////////////////////
                /// </summary>
                return "OJO ESTA MAL Elija la cuenta de la que proviene la transferencia:";
                foreach (PaymentMethod item in request.Profile.PaymentMethods)
                {
                    Output.PrintLine($"{request.Profile.PaymentMethods.IndexOf(item)}. {item.Name}");
                }

                int z = IntImput.GetInput("Cuenta a debitar:");
                double monto = IntImput.GetInput("Ingrese el monto a transferir:");
                string concepto = StringImput.GetInput("Escriba el concepto de la transferencia:");
                Currency currency = request.Profile.PaymentMethods[z].Currency;

                Output.PrintLine("Elija la cuenta a la que envía la transferencia:");
                foreach (PaymentMethod item in request.Profile.PaymentMethods)
                {
                    Output.PrintLine($"{request.Profile.PaymentMethods.IndexOf(item)}. {item.Name}");
                }
                int destino = IntImput.GetInput("Cuenta a acreditar:");
                movimiento = request.Profile.MakeInternalTransfer(concepto, monto, currency, request.Profile.PaymentMethods[z], request.Profile.PaymentMethods[destino]);
                Output.PrintLine("Movimiento realizado con éxito.");
            }
            else
            {
                return base.Next.Handle(request);
            }
        }
    }
}