using System;
using System.Collections.Generic;

namespace Library
{
    //Esta clase abstracta define un tipo genérico Alerta, con el comportamiento común a todas las alertas
    //La operación TrackLevel será polimórfica, ya que cada alerta definirá un comportamiento propio 
    //Según lo que desee controlar cada alerta
    public abstract class Alert
    {
        public string Name { get; protected set; }
        public double Level { get; protected set; }
        public bool IsOn { get; protected set; }
        public string Message { get; protected set; }
        public Alert(string name, double level, string message)
        {
            this.Name = name;
            this.Level = level;
            this.Message = message;
            this.IsOn = false;
        }
        public virtual void ChangeLevel(double newvalue)
        {
            this.Level = newvalue;
        }
        public virtual void TurnOnAlert()
        {
            this.IsOn = true;
        }
        public virtual void TurnOffAlert()
        {
            this.IsOn = false;
        }
        public virtual void TrackLevel(List<PaymentMethod> list)
        {
            
        }
    }
}