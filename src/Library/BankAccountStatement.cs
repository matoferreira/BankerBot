using System;
using System.Collections.Generic;

namespace Library
{
    public class BankAccountStatement : Statement
    {
        public List<Transactions> transactions { get; private set; }
        BankAccountStatement(Currency currency, DateTime date)
        {
            this.Currency = currency;
            this.Date = date;
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