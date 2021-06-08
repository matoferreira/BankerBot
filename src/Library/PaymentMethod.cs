using System;

namespace Library
{
    public abstract class PaymentMethod
    {
        //Chequear los protected
        protected Currency Currency {get ; private set;}
        public DateTime Date {get; private set;}
        protected Statement CurrentStatement {get; private set;}
        protected double Balance {get; private set;}

        //Va constructor?
        public virtual void AddTransaction(string concept, double ammount)
        {

        }
        public virtual void RemoveTransaction(string concept, double ammount)
        {

        }
        public string GetCurrency()
        {
            return Currency;
        }
        public double GetBalance()
        {
            return Balance;
        }
    }
}