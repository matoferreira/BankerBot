using System;
using System.Collections.Generic;

namespace Library
{
    public class BankAccount : PaymentMethod
    {
        private List<BankAccountStatement> StatementList {get; set;}

        public override void AddTransaction(string concept, double ammount)
        {
            
        }
        public override void RemoveTransaction(string concept, double ammount)
        {
           
        }
    }
}