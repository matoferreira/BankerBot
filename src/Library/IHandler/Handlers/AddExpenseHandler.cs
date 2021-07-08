using System;

namespace Library
{
    public class AddExpenseHandler : AbstractHandler
    {
        public IStringInput StringImput = Singleton<ConsoleReader>.Instance;
        public IIntInput IntImput = Singleton<IntConsoleReader>.Instance;
        public override void Handle(Request request)
        {
            if (request.Content == "/agregargasto")
            {
                Output.PrintLine("Elija la cuenta a la que agrega el gasto:");
                foreach (PaymentMethod item in request.Profile.PaymentMethods)
                {
                    Output.PrintLine($"{request.Profile.PaymentMethods.IndexOf(item)}. {item.Name}");
                }
                int z = IntImput.GetInput("Cuenta:");
                double monto = IntImput.GetInput($"Ingrese el monto del gasto:");
                string concepto = StringImput.GetInput("Escriba el concepto del gasto:");
                ExpenseType tipo = new ExpenseType(StringImput.GetInput("Ingrese el tipo del gasto:"));
                string moneda = StringImput.GetInput("Ingrese la moneda:");
                Currency currency = new Currency(moneda);
                request.Profile.AddMovement(request.Profile.PaymentMethods[z], concepto, monto, currency, false);
                Output.PrintLine("Movimiento realizado con éxito.");
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}