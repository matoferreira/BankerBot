using System;

namespace Library
{
    public abstract class Transactions
    {
        public Currency Currency { get ; private set; }
        public DateTime Date { get; private set; }
       

        public virtual void AddTransaction(string concept, double ammount)
        {

        }
        public virtual void RemoveTransaction(string concept, double ammount)
        {
        }

    }
}