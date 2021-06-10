using System;

namespace Library
{
    //Creamos una clase abstracta PaymentMethod, que es un producto financiero o una billetera que se puede usar para operar con dinero.
    //La idea de utilizar esta clase es cumplir con el principio de LSP, Creditcard, BankAccount y Wallet seran clases polimórficas
    //PaymentMethod puede ser sustituido por cualquier clase subtipo de ésta.
    public abstract class PaymentMethod
    {
        
        public Currency Currency { get; protected set; }
        protected double Balance { get; set; }
        public virtual double GetBalance()
        {
            return 0;
        }
    }
}