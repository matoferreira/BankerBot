using System;

namespace Library
{
    public class NewBankAccountHandler: AbstractHandler
    {
        public IStringInput StringImput = Singleton<ConsoleReader>.Instance;
        public override void Handle(Request request)
        {
            string name = StringImput.GetInput("Ingrese el nombre del banco");
            string moneda = StringImput.GetInput("Ingrese la moneda");

            Currency currency = new Currency(moneda);
            BankAccount newAccount = new BankAccount(name, currency);
            int balance = Convert.ToInt32(StringImput.GetInput("Ingrese el saldo de la cuenta"));
            newAccount.CurrentStatement.ChangeBalance(balance);
            
            //Faltaría agregar este método al perfil del usuario para que quede guardado
            //profile.AddPaymentmethod(newAccount);
            base.Handle(request);
        }
    }
}