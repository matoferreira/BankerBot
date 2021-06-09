using System;
using System.Collections.Generic;

namespace Library
{
    public abstract class Statement
    {
        public Currency Currency { get; protected set; }
        public DateTime Date { get; protected set; }
        public List<Transactions> Transactions { get; protected set;}
        public virtual void AddTransaction()
        {

        }
        public virtual void RemoveTransaction()
        {

        }
        public virtual double GetBalance()
        {
            return 0;
        }
        public virtual double AccumulateExpenses()
        {
            return 0;
        }
    }
}