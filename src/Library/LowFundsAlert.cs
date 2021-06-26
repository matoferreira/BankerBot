using System;
using System.Collections.Generic;

namespace Library
{
    public class LowFundsAlert : Alert
    {
        public double fondostotales { get; private set; }
        public LowFundsAlert() : base("Low Funds Alert", -1, "Alerta: Fondos en cuenta por debajo del nivel deseado")
        {

        }
        public override void TrackLevel(List<PaymentMethod> list)
        {
            if (this.Level != -1)
            {
                double fondos = 0;
                foreach (PaymentMethod item in list)
                {
                    if (typeof(BankAccount).IsInstanceOfType(item))
                    {
                        fondos = fondos + item.GetBalance();
                    }
                    if (typeof(Wallet).IsInstanceOfType(item))
                    {
                        fondos = fondos + item.GetBalance();
                    }
                }
                if (fondos > this.Level)
                {
                    this.IsOn = true;
                    this.fondostotales = fondos;
                }
                else
                {
                    this.IsOn = false;
                    this.fondostotales = fondos;
                }
            }
        }
    }
}