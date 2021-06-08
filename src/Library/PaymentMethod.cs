using System;

namespace Library
{
    public abstract class PaymentMethod
    {
        protected Currency Moneda;
        public DateTime Date;
        protected Statement CurrentStatement;
        public double Balance;

        //Va constructor?
        public void AddTransaction(string concept, double ammount)
        {

        }
        public void RemoveTransaction(string concept, double ammount)
        {

        }
    }
}