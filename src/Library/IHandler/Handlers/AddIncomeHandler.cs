using System;

namespace Library
{
    public class AddIncomeHandler : AbstractHandler
    {
        public IStringInput StringImput = Singleton<ConsoleReader>.Instance;
        public IIntInput IntImput = Singleton<IntConsoleReader>.Instance;
        public override void Handle(Request request)
        {
            if (request.Content == "/AgregarIngreso")
            {
                Output.PrintLine("Elija la cuenta a la que agrega el ingreso:");
                foreach (PaymentMethod item in profile.PaymentMethods)
                {
                    Output.PrintLine($"{profile.PaymentMethods.IndexOf(item)}. {item.Name}");
                }
                int z = IntImput.GetInput("Cuenta:");
                double monto = IntImput.GetInput($"Ingrese el monto del ingreso:");
                string concepto = StringImput.GetInput("Escriba el concepto del Ingreso:");
                string moneda = StringImput.GetInput("Ingrese la moneda:");
                Currency currency = new Currency(moneda);
                profile.AddMovement(profile.PaymentMethods[z], concepto, monto, currency, true);
                Output.PrintLine("Movimiento realizado con éxito.");
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}