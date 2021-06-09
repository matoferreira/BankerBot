using System;

namespace Library
{
    public abstract class PaymentMethod
    {
        
        protected Currency Currency {get ; private set;}
        protected DateTime Date {get; private set;}
        protected Statement CurrentStatement {get; private set;}
        protected double Balance {get; private set;}

        public virtual void AddTransaction(string concept, double ammount)
        {

        }
        public virtual void RemoveTransaction(string concept, double ammount)
        {

        }

        //Pasarlo a las clases
        public virtual string GetCurrency()
        {
           return null;
        }
        public virtual double GetBalance()
        {
            return 0;
        }
    }
}