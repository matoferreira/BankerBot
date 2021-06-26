using System;
using System.Collections.Generic;

namespace Library
{
    public class UserProfile : BaseComponent, IObserver
    {
        public List<Alert> Alerts { get; private set; }
        public List<PaymentMethod> PaymentMethods { get; private set; }
        public UserProfile()
        {
            this.PaymentMethods = new List<PaymentMethod>();
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
            }
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
