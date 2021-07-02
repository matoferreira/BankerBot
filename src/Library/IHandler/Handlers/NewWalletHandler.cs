using System;

namespace Library
{
    public class NewWalletHandler: AbstractHandler
    {
        public IStringInput StringImput = Singleton<ConsoleReader>.Instance;
        public override void Handle(Request request)
        {
            string moneda = StringImput.GetInput("Ingrese la moneda de la billetera");
            double limit = Convert.ToDouble(StringImput.GetInput("Ingrese el límite de la tarjeta"));
            Currency currency = new Currency(moneda);
            SubWallet subWallet = new SubWallet(moneda, currency);
            Wallet wallet = new Wallet(subWallet);
            //Hay que chequear acá que al usuario lo tenemos que crear con una wallet y solo
            //hacerlo agregar subwalllets.
            //Faltaría agregar este método al perfil del usuario para que quede guardado
            //profile.AddPaymentmethod(newAccount);
            base.Handle(request);
        }
    }
}