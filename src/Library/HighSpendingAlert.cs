using System;
using System.Collections.Generic;

namespace Library
{
    public class HighSpendingAlert : Alert
    {
        public double gastosaltos { get; private set; }
        public HighSpendingAlert() : base("High Spending Alert", -1, "Alerta: Gastos de Tarjetas superaron el Límite deseado")
        {
        }
        public override void TrackLevel(List<PaymentMethod> list)
        {
            if (this.Level != -1)
            {
                double gastos = 0;
                foreach (PaymentMethod item in list)
                {
                    if (typeof(CreditCard).IsInstanceOfType(item))
                    {
                        gastos = gastos + item.GetBalance();
                    }
                }
                if (gastos > this.Level)
                {
                    this.IsOn = true;
                    this.gastosaltos = gastos;
                }
                else
                {
                    this.gastosaltos = 0;
                }
            }
        }
    }
}