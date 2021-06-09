using System;
using System.Collections.Generic;

namespace Library
{
    //La clase SubWallet es una clase componente de Wallet, de tal manera que solo existe
    //como un componente de Wallet y no por si sola. Esto lo hicimos como alternativa a la herencia.
    //A su vez, subWallet es la experta en realizar las transacciones necesarias para ella misma.
    //Dado que Wallet será una lista de SubWallets.
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