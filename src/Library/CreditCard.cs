using System;
using System.Collections.Generic;

namespace Library
{
    public class CreditCard : PaymentMethod
    {
        private double Limit {get ;}
        public List<CardStatement> StatementList {get; private set;}
        //falta agregar constructor
        public CreditCard(Currency currency, double limit)
        {
            
        }
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
        public override string GetCurrency()
        {
            return null;
        }
        public override double GetBalance()
        {
            return 0;
        }
    }
}