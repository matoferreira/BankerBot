using System;
using System.Collections.Generic;
//Esta alerta se dedica a controlar la meta de ahorro mensual que tiene el usuario y muestra una
//notificación cuando se supera la meta mensual definida por el usuario.
//Al instanciarse, se le asigna un límite negativo, -1, solo cuando el usuario configure un valor positivo
//como límite pasará a mostrar la notificación.
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
                else
                {
                    this.IsOn = false;
                    this.ahorrototal = ahorro;
                }
            }
        }
    }
}