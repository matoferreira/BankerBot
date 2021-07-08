using System;

namespace Library
{
    public class AddInternalTransferHandler : AbstractHandler
    {
        public IStringInput StringImput = Singleton<ConsoleReader>.Instance;
        public IIntInput IntImput = Singleton<IntConsoleReader>.Instance;
        public override void Handle(Request request)
        {
            if (request.Content == "/AgregarTransferenciaInterna")
            {
                bool movimiento;
                Output.PrintLine("Elija la cuenta de la que proviene la transferencia:");
                foreach (PaymentMethod item in profile.PaymentMethods)
                {
                    Output.PrintLine($"{profile.PaymentMethods.IndexOf(item)}. {item.Name}");
                }

                int z = IntImput.GetInput("Cuenta a debitar:");
                double monto = IntImput.GetInput("Ingrese el monto a transferir:");
                string concepto = StringImput.GetInput("Escriba el concepto de la transferencia:");
                Currency currency = profile.PaymentMethods[z].Currency;

                Output.PrintLine("Elija la cuenta a la que envía la transferencia:");
                foreach (PaymentMethod item in profile.PaymentMethods)
                {
                    Output.PrintLine($"{profile.PaymentMethods.IndexOf(item)}. {item.Name}");
                }
                int destino = IntImput.GetInput("Cuenta a acreditar:");
                movimiento = profile.MakeInternalTransfer(concepto, monto, currency, profile.PaymentMethods[z], profile.PaymentMethods[destino]);
                Output.PrintLine("Movimiento realizado con éxito.");
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}