using System;
using System.Collections.Generic;

namespace Library
{
    public class CardStatement : Statement
    {
        public double limit { get; private set; }
        public List<Transactions> transactions { get; private set; }
        CardStatement(Currency currency, DateTime date, double limit)
        {
            this.Currency = currency;
            this.Date = date;
            this.limit = limit;
            this.transactions = new List<Transactions>();
        }
        public override void AddTransaction()
        {

        }
        public override void RemoveTransaction()
        {

        }
        public override double GetBalance()
        {
            return 0;
        }
        public override double AccumulateExpenses()
        {
            return 0;
        }
    }
}