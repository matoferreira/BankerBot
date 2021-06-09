using System;
using System.Collections.Generic;

namespace Library
{
    public class CreditCard : PaymentMethod
    {
        private double Limit { get; set; }
        public List<CardStatement> StatementList {get; private set;}
        public CardStatement CurrentStatement { get; protected set; }
        public CreditCard(Currency currency, DateTime date, double limit)
        {
            this.CurrentStatement = new CardStatement(currency, date, limit, 0);
            this.StatementList = new List<CardStatement>();
        }
        public double GetLimit()
        {
            return Limit;
        }
        public void SetNewLimit (double NewLimit)
        {

        }
        public override double GetBalance()
        {
            return 0;
        }
        public void NewMonth()
        {
            
        }
    }
}