using System;
using System.Collections.Generic;

namespace Library
{
    public class SubWallet
    {
        private string Name {get ;}
        private Currency Currency {get ;}
        private double Balance {get ;}
        private List<Transactions> Transactions {get;}
        public SubWallet (string Name, Currency currency)
        {
            this.Name = Name;
            this.Currency = currency;
            this.Balance = 0;
            this.Transactions = new List<Transactions>();
        }
        public void AddTransaction()
        {

        }
        public void RemoveTransaction()
        {
            
        }

    }
}