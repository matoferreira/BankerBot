using System;

namespace Library
{
    public class NewCreditCardHandler : AbstractHandler
    {
        public IStringInput StringImput = Singleton<ConsoleReader>.Instance;
        public override object Handle(Request request)
        {
            if (request.Content == "/agregartarjeta")
            {
                string name = StringImput.GetInput("Ingrese el nombre de la tarjeta:");
                string moneda = StringImput.GetInput("Ingrese la moneda:");
                double limit = Convert.ToDouble(StringImput.GetInput("Ingrese el límite de la tarjeta:"));

                Currency currency = new Currency(moneda);
                CreditCard newCard = new CreditCard(name, currency, limit);
                
                request.Profile.AddPaymentMethod(newCard);
                return "Medio de pago agregado con éxito.";
            }
            else
            {
                return base.Next.Handle(request);
            }
        }
    }
}