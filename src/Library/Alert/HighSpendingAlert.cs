using System;
using System.Collections.Generic;
//Esta alerta se dedica a controlar los gastos mensuales que se hacen con tarjetas de crédito, y muestra una
//alerta cuando se supera un límite mensual definido por el usuario.
//Al instanciarse, se le asigna un límite negativo, -1, solo cuando el usuario configure un valor positivo
//como límite pasará a mostrar la advertencia.
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
                    this.IsOn = false;
                    this.gastosaltos = 0;
                }
            }
        }
    }
}