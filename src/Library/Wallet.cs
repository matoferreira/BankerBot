//La clase Wallet representa la billetera, t es una clase compuesta, que delega parte de sus responsabilidades a la clase SubWallet.
//Wallet es la clase Experta (patrón Expert) en calcular el balance total de la billetera, dado a que es en sí,
//una lista de SubWallets, por esta razón, es la que conoce los balances de cada una para calcular el balance total.
using System;
using System.Collections.Generic;

namespace Library
{
    
    
    public class Wallet : PaymentMethod
    {
        public List<SubWallet> SubWalletList { get; private set; }
        public List<Currency> CurrencyList { get; private set; }
        
        public Wallet(SubWallet subwallet)
        {
            this.SubWalletList = new List<SubWallet>();
            this.CurrencyList = new List<Currency>();
            this.SubWalletList.Add(subwallet);
        }
        public void AddSubWallet (SubWallet newSubWallet)
        {

        }
        public void RemoveSubWallet (SubWallet subwallet)
        {

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