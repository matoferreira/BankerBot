using System;
using System.Collections.Generic;

namespace Library
{
    //Creamos una clase abstracta PaymentMethod, que es un producto financiero o una billetera que se puede usar para operar con dinero.
    //La idea de utilizar esta clase es cumplir con el principio de LSP, Creditcard, BankAccount y Wallet seran clases polimórficas
    //PaymentMethod puede ser sustituido por cualquier clase subtipo de ésta.
    //Tambien utilizamos el patrón observer para que las alertas puedan ser actualizadas con la información que necesitan para operar
    //los paymentMethod seran los IObservables y el Observer será el UserProfile quien los crea.
    public abstract class PaymentMethod : IPaymentMethod
    {

        public Currency Currency { get; protected set; }
        public string Name { get; protected set; }
        protected List<IObserver> observers = new List<IObserver>();

        public virtual Statement CurrentStatement { get; protected set; }
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
        public virtual bool AddMovement(string concept, double ammount, Currency currency, bool isPositive, ExpenseType basicType)
        {
            Transactions tran = CurrentStatement.AddTransaction(concept, ammount, currency, isPositive);
            if (tran != null)
            {
                if (isPositive == false)
                {
                    ((Expense)tran).ChangeExpenseType(basicType);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public virtual string GetSavings()
        {
            return null;
        }
    }
}