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
        public string Name { get; private set; }
        public Currency Currency { get; private set; }
        public WalletStatement Statement { get; private set; }
        public SubWallet (string Name, Currency currency)
        {
            this.Name = Name;
            this.Currency = currency;
            this.Statement = new WalletStatement(Currency);
        }
    }
}