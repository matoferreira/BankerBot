using System;

namespace Library
{
    public class AddIncomeHandler : AbstractHandler
    {
        public IStringInput StringImput = Singleton<ConsoleReader>.Instance;
        public IIntInput IntImput = Singleton<IntConsoleReader>.Instance;
        public override void Handle(Request request)
        {
            if (request.Content == "/agregaringreso")
            {
                Output.PrintLine("Elija la cuenta a la que agrega el ingreso:");
                foreach (PaymentMethod item in request.Profile.PaymentMethods)
                {
                    Output.PrintLine($"{request.Profile.PaymentMethods.IndexOf(item)}. {item.Name}");
                }
                int z = IntImput.GetInput("Cuenta:");
                double monto = IntImput.GetInput($"Ingrese el monto del ingreso:");
                string concepto = StringImput.GetInput("Escriba el concepto del Ingreso:");
                string moneda = StringImput.GetInput("Ingrese la moneda:");
                Currency currency = new Currency(moneda);
                request.Profile.AddMovement(request.Profile.PaymentMethods[z], concepto, monto, currency, true);
                Output.PrintLine("Movimiento realizado con éxito.");
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}