using System;
using System.Collections.Generic;

namespace Library
{
    //
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