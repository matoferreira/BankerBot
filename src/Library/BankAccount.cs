using System;
using System.Collections.Generic;

namespace Library
{
    public class BankAccount : PaymentMethod
    {
        private List<BankAccountStatement> StatementList {get; set;}

        public BankAccount(Currency currency)
        {

        }
        public override void AddTransaction(string concept, double ammount)
        {
            
        }
        public override void RemoveTransaction(string concept, double ammount)
        {
           
        }
        public override string GetCurrency()
        {
            return null;
        }
        public override double GetBalance()
        {
            return 0;
        }

    }
}