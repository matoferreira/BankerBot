using System;

namespace Library
{
    public class NewCreditCardHandler: AbstractHandler
    {
        public IStringInput StringImput = Singleton<ConsoleReader>.Instance;
        public override void Handle(Request request)
        {
            string name = StringImput.GetInput("Ingrese el nombre de la tarjeta");
            string moneda = StringImput.GetInput("Ingrese la moneda");
            double limit = Convert.ToDouble(StringImput.GetInput("Ingrese el límite de la tarjeta"));
            Currency currency = new Currency(moneda);
            CreditCard newCard = new CreditCard(name, currency, limit);
            
            //Faltaría agregar este método al perfil del usuario para que quede guardado
            //profile.AddPaymentmethod(newAccount);
            base.Handle(request);
        }
    }
}