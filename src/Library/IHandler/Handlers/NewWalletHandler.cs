using System;

namespace Library
{
    public class NewWalletHandler : AbstractHandler
    {
        public IStringInput StringImput = Singleton<ConsoleReader>.Instance;
        public override void Handle(Request request)
        {
            if (request.Content == "/agregarbilletera")
            {
                string moneda = StringImput.GetInput("Ingrese la moneda de la billetera:");

                Currency currency = new Currency(moneda);
                PaymentMethod wallet = profile.PaymentMethods.Find(x => x.Name == "Billetera");
                ((Wallet)wallet).AddSubWallet(new SubWallet(moneda, currency));
                Output.PrintLine("Medio de pago agregado con éxito.");
                base.Handle(request);
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}