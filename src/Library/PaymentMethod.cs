using System;

namespace Library
{
    //Creamos una clase abstracta PaymentMethod
    //La idea de utilizar esta clase es cumplir con el principio de LSP.
    //Cuando se necesite hacer una transacción, se pedirá un objeto de tipo PaymentMethod
    //que puede ser sustituido por cualquier clase subtipo de ésta.
    public abstract class PaymentMethod
    {
        
        public Currency Currency { get; protected set; }
        public DateTime Date { get; protected set; }
        protected double Balance { get; set; }
        public virtual double GetBalance()
        {
            return 0;
        }
    }
}