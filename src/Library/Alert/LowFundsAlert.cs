using System;
using System.Collections.Generic;
//Esta alerta se dedica a controlar los fondos que se tienen guardados en las cuentas bancarias y en la billetera,
//muestra una alerta cuando estos son menores a un valor definido por el usuario.
//Al instanciarse, se le asigna un límite negativo, -1, solo cuando el usuario configure un valor positivo
//como límite pasará a mostrar la advertencia.
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