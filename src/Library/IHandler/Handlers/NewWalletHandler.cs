using System;

namespace Library
{
    public class NewWalletHandler : AbstractHandler
    {
        public IStringInput StringImput = Singleton<ConsoleReader>.Instance;
        public override void Handle(Request request)
        {
            if (request.Content == "/AgregarBilletera")
            {
                string moneda = StringImput.GetInput("Ingrese la moneda de la billetera:");

                Currency currency = new Currency(moneda);
                SubWallet subWallet = new SubWallet(moneda, currency);
                
                this.profile.AddSubWallet(subWallet);
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