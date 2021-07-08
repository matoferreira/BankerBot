using System;

namespace Library
{
    public class NewWalletHandler : AbstractHandler
    {
        public IStringInput StringImput = Singleton<ConsoleReader>.Instance;
        public override object Handle(Request request)
        {
            if (request.Content == "/agregarbilletera")
            {
                string moneda = StringImput.GetInput("Ingrese la moneda de la billetera:");

                Currency currency = new Currency(moneda);
                PaymentMethod wallet = request.Profile.PaymentMethods.Find(x => x.Name == "Billetera");
                ((Wallet)wallet).AddSubWallet(new SubWallet(moneda, currency));
                return "Medio de pago agregado con éxito.";
            }
            else
            {
                return base.Next.Handle(request);
            }
        }
    }
}