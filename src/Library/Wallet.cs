using System;
using System.Collections.Generic;

namespace Library
{
    public class Wallet : PaymentMethod
    {
        private List<SubWallet> SubWalletList {get; set;}
        private List<Currency> CurrencyList {get; set;}
        
        public Wallet(SubWallet subwallet)
        {

        }
        public void AddSubWallet (SubWallet newSubWallet)
        {

        }
        public void RemoveSubWallet (SubWallet subwallet)
        {

        }
        public override string GetCurrency()
        {
            return null;
        }
        public double GetBalanceByCurrency (Currency currency)
        {
            return 0;
            //En este método se devuelve el balance por cada moneda
            //Se puso "0" para evitar el error de compilación por esperar un retorno double
        }
        public override double GetBalance()
        {
            return 0;
        }
    }
}