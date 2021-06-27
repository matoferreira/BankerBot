//La clase Wallet representa la billetera, t es una clase compuesta, que delega parte de sus responsabilidades a la clase SubWallet.
//Wallet es la clase Experta (patrón Expert) en calcular el balance total de la billetera, dado a que es en sí,
//una lista de SubWallets, por esta razón, es la que conoce los balances de cada una para calcular el balance total.
using System;
using System.Collections;
using System.Collections.Generic;

namespace Library
{
    
    
    public class Wallet : PaymentMethod
    {
        public List<SubWallet> SubWalletList { get; private set; }
        public List<Currency> CurrencyList { get; private set; }
        
        public Wallet(SubWallet subwallet)
        {
            this.Name = "Billetera";
            this.SubWalletList = new List<SubWallet>();
            this.CurrencyList = new List<Currency>();
            this.SubWalletList.Add(subwallet);
        }
        public void AddSubWallet (SubWallet newSubWallet)
        {
            SubWalletList.Add(newSubWallet);
        }
        public void RemoveSubWallet (SubWallet subwallet)
        {
            SubWalletList.Remove(subwallet);
        }

        //Para resolver la forma de aplicar este método se usó la siguiente referencia
        //https://github.com/ucudal/PII_Conceptos_De_POO/blob/master/Capitulos/3_Tipos_Genericos/3_2_Desarrollo.md
        public double GetBalanceBySubWallet (SubWallet subWallet)
        {
            double result = 0;
            result+=subWallet.Statement.GetBalance();
            this.NotifyObservers();
            return result;
        }

        public override double GetBalance()
        {
            double result = 0;
            foreach (SubWallet subwallet in this.SubWalletList)
            {
                result += subwallet.Statement.GetBalance()*subwallet.Currency.ExchangeRate;
            }
            this.NotifyObservers();
            return result;
        }
    }
}