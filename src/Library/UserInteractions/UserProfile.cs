using System;
using System.Collections.Generic;
//Esta clase almacena todas la información del usuario. Agrega los paymentMethod que es usuario configuró y las
//alertas que utiliza, también permite modificarlas. Es el Creator de los PaymentMethod, y tambien los observa
//según patrón observer, pra notificar de sus cambios a las alertas, quienes necesitan conocerlos para
//operar.
namespace Library
{
    public class UserProfile : IObserver
    {
        public List<Alert> Alerts { get; private set; }
        public List<PaymentMethod> PaymentMethods { get; private set; }
        private Wallet wallet;
        public UserProfile()
        {
            this.PaymentMethods = new List<PaymentMethod>();
            wallet = new Wallet(new SubWallet("Pesos", new Currency("Pesos")));
            this.AddPaymentMethod(wallet);
            this.Alerts = new List<Alert>();
            Alerts.Add(new HighSpendingAlert());
            Alerts.Add(new SavingsTargetAlert());
            Alerts.Add(new LowFundsAlert());
        }
        public void AddAlert(Alert newAlert)
        {
            if (!Alerts.Contains(newAlert))
            {
                Alerts.Add(newAlert);
            }
        }
        public void RemoveAlert(Alert Alert)
        {
            if (Alerts.Contains(Alert))
            {
                Alerts.Remove(Alert);
            }
        }
        public void AddPaymentMethod(PaymentMethod newMethod)
        {
            if (!PaymentMethods.Contains(newMethod))
            {
                PaymentMethods.Add(newMethod);
                newMethod.Subscribe(this);
            }
        }

        public void AddSubWallet (SubWallet newSubWallet)
        {
            this.wallet.AddSubWallet(newSubWallet);
        }

        public void RemovePaymentMethod(PaymentMethod method)
        {
            if (PaymentMethods.Contains(method))
            {
                PaymentMethods.Remove(method);
            }
        }

        public void Update()
        {
            foreach (Alert alert in Alerts)
            {
                alert.TrackLevel(PaymentMethods);
            }
        }

    }
}
