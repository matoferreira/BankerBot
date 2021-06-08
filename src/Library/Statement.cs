using System;

namespace Library
{
    public abstract class Statement
    {
        protected Currency Moneda;
        protected DateTime Fecha = new DateTime();
        public virtual void AddTransaction()
        {

        }
        public virtual void RemoveTransaction()
        {

        }
        public virtual double GetBalance()
        {

        }
        public virtual double AccumulateExpenses()
        {
            
        }
    }
}