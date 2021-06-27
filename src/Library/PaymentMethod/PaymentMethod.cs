using System;
using System.Collections.Generic;

namespace Library
{
    //Creamos una clase abstracta PaymentMethod, que es un producto financiero o una billetera que se puede usar para operar con dinero.
    //La idea de utilizar esta clase es cumplir con el principio de LSP, Creditcard, BankAccount y Wallet seran clases polimórficas
    //PaymentMethod puede ser sustituido por cualquier clase subtipo de ésta.
    public abstract class PaymentMethod : IPaymentMethod
    {
        
        public Currency Currency { get; protected set; }
        public string Name { get; protected set; }
        protected List<IObserver> observers = new List<IObserver>();

        public Statement CurrentStatement { get; protected set; }
        public virtual double GetBalance()
        {
            return 1;
        }

        public void Subscribe(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            this.observers.Remove(observer);
        }

        public void NotifyObservers()
        {
             foreach (IObserver observer in observers)
            {
                observer.Update();
            }
        }
    }
}