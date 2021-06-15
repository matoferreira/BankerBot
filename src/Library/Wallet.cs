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

        //En este método necesito recorrer los WalletStatment en SubWalletList para saber los Currency de cada uno pero no sé como referenciar directo al
        //Statement de cada SubWallet en SubWalletList
        //Para resolver la forma de aplicar este método se uso la siguiente referencia
        //https://github.com/ucudal/PII_Conceptos_De_POO/blob/master/Capitulos/3_Tipos_Genericos/3_2_Desarrollo.md
        public IList GetBalanceByCurrency (Currency currency)
        {
            //Cambiar a clases de alto nivel
            IList result = new ArrayList();
            foreach (WalletStatement Statement in this.SubWalletList)
            {
                if (Statement.Currency.Equals(currency))
                {
                    result.Add(Statement.GetBalance());
                }
            }
            return result;
        }

        //Para solucionar el error de abajo se me ocurre hacer un supertipo (o interfaz que no tiene implementación) PaymentMethod
        //Con dos subtipos uno para wallet y el otro para los demas paymenthmethod
        public override IList GetBalance()
        {
            IList result = new ArrayList();
            foreach (WalletStatement Statement in this.SubWalletList)
            {
                result.Add(Statement.GetBalance());
            }
            return result;
        }
    }
}