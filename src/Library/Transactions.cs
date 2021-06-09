using System;

namespace Library
{
    public abstract class Transactions
    {
        protected Currency Currency {get ; private set;}
        protected DateTime Date {get; private set;}
       

        public virtual void AddTransaction(string concept, double ammount)
        {

        }
        public virtual void RemoveTransaction(string concept, double ammount)
        {


    }
}