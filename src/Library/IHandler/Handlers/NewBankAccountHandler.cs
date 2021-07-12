using System;

namespace Library
{
    public class NewBankAccountHandler : AbstractHandler
    {
        public IStringInput StringImput = Singleton<ConsoleReader>.Instance;
        public override void Handle(Request request)
        {
            if (request.Content == "/agregarcuentabancaria")
            {
                string name = StringImput.GetInput("Ingrese el nombre del banco:");
                string moneda = StringImput.GetInput("Ingrese la moneda:");

                Currency currency = new Currency(moneda);
                BankAccount newAccount = new BankAccount(name, currency);
                double balance = Convert.ToDouble(StringImput.GetInput("Ingrese el saldo de la cuenta:"));
                Transactions trans = newAccount.CurrentStatement.AddTransaction("Balance Inicial", balance, currency, true);
                request.Profile.AddPaymentMethod(newAccount);
                Output.PrintLine("Medio de pago agregado con exito.");
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}