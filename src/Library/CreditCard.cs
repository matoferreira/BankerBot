using System;
using System.Collections.Generic;

namespace Library
{
    public class CreditCard : PaymentMethod
    {
        private double Limit {get ; set;}

        //Este metodo podría ser abstracto en la clase PaymentMethod
        public List<CardStatement> StatementList {get; private set;}
        //falta agregar constructor
        public double GetLimit()
        {
            return Limit;
        }
        public void SetNewLimit (double NewLimit)
        {
            NewLimit = this.Limit;
        }
        public override void AddTransaction(string concept, double ammount)
        {

        }
        public override void RemoveTransaction(string concept, double ammount)
        {

        }
    }
}