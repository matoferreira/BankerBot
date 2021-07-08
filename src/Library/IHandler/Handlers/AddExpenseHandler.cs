using System;

namespace Library
{
    public class AddExpenseHandler : AbstractHandler
    {
        public IStringInput StringImput = Singleton<ConsoleReader>.Instance;
        public IIntInput IntImput = Singleton<IntConsoleReader>.Instance;
        public override void Handle(Request request)
        {
            if (request.Content == "/AgregarGasto")
            {
                Output.PrintLine("Elija la cuenta a la que agrega el gasto:");
                foreach (PaymentMethod item in profile.PaymentMethods)
                {
                    Output.PrintLine($"{profile.PaymentMethods.IndexOf(item)}. {item.Name}");
                }
                int z = IntImput.GetInput("Cuenta:");
                double monto = IntImput.GetInput($"Ingrese el monto del gasto:");
                string concepto = StringImput.GetInput("Escriba el concepto del gasto:");
                ExpenseType tipo = new ExpenseType(StringImput.GetInput("Ingrese el tipo del gasto:"));
                string moneda = StringImput.GetInput("Ingrese la moneda:");
                Currency currency = new Currency(moneda);
                profile.AddMovement(profile.PaymentMethods[z], concepto, monto, currency, false);
                Output.PrintLine("Movimiento realizado con éxito.");
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}