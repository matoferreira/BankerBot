using System;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;


namespace Library
{
    public class NewBankAccountHandler : AbstractHandler
    {
        public IStringInput StringImput = Singleton<ConsoleReader>.Instance;
        public override object Handle(Request request)
        {
            if (request.Content == "/agregarcuentabancaria")
            {
                
                string name = StringImput.GetInput("Ingrese el nombre del banco:");
                string moneda = StringImput.GetInput("Ingrese la moneda:");

                Currency currency = new Currency(moneda);
                BankAccount newAccount = new BankAccount(name, currency);
                
                int balance = Convert.ToInt32(StringImput.GetInput("Ingrese el saldo de la cuenta:"));
                newAccount.CurrentStatement.ChangeBalance(balance);
            
                request.Profile.AddPaymentMethod(newAccount);
                return "Medio de pago agregado con éxito.";
            }
            else
            {
                return base.Next.Handle(request);
            }
        }
    }
}