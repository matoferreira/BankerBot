using System;
using System.Collections.Generic;

//Representa las tarjetas de crédito que tiene el usuario
//Es un Creator de CreditCardStatement porque los crea y almacena.

namespace Library
{
    public class CreditCard : PaymentMethod
    {
        public double limit { get; private set; }
        public List<CardStatement> StatementList {get; private set;}
        public new CardStatement CurrentStatement { get; protected set; }
        public string CardName { get; private set; }
        public CreditCard(string cardName, Currency currency, double limit)
        {
            this.CardName = cardName;
            this.CurrentStatement = new CardStatement(currency, DateTime.Today, limit, 0);
            this.StatementList = new List<CardStatement>();
        }
        public void SetNewLimit (double NewLimit)
        {
            this.limit = NewLimit;
        }
        public override double GetBalance()
        {
            return CurrentStatement.GetBalance();
        }
        public void NewMonth()
        {
            CardStatement newStatement = new CardStatement(Currency, DateTime.Now, this.limit, this.GetBalance());
            StatementList.Add(this.CurrentStatement);
            this.CurrentStatement = newStatement;  
        }
    }
}