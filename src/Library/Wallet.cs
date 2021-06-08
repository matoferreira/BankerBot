using System;
using System.Collections.Generic;

namespace Library
{
    public class Wallet : PaymentMethod
    {
        private List<SubWallet> SubWalletList {get; set;}
        private List<Currency> CurrencyList {get; set;}
        private double TotalBalance {get; set;}
        
        public void AddSubWallet (SubWallet newSubWallet)
        {

        }
        public void RemoveSubWallet (SubWallet subwallet)
        {

        }
        public List<Currency> GetAllCurrency()
        {
            return this.CurrencyList;
        }
        public double GetBalanceByCurrency (Currency currency)
        {
            return 2;
            //En este método se devuelve el balance por cada moneda
            //Se puso "2" para evitar el error de compilación por esperar un retorno double
        }
        public double GetTotalBalance()
        {
            return this.Balance;
        }
    }
}