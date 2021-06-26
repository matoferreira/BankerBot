using System;
using System.Collections.Generic;

namespace Library
{
    public class SavingsTargetAlert : Alert
    {
        public double ahorrototal { get; private set; }
        public SavingsTargetAlert() : base("Savings Target Alert", -1, "Notificación: Monto a ahorrar alcanzado")
        {

        }
        public override void TrackLevel(List<PaymentMethod> list)
        {
            if (this.Level != -1)
            {
                double ahorro = 0;
                foreach (PaymentMethod item in list)
                {
                    if (typeof(BankAccount).IsInstanceOfType(item))
                    {
                        ahorro = ahorro + item.GetBalance();
                    }
                }
                if (ahorro > this.Level)
                {
                    this.IsOn = true;
                    this.ahorrototal = ahorro;
                }
            }
        }
    }
}