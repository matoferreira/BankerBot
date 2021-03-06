using System;
using System.Collections.Generic;

//Representa las tarjetas de crédito que tiene el usuario
//Es un Creator de CreditCardStatement porque los crea y almacena.

namespace Library
{
    public class CreditCard : PaymentMethod
    {
        public double Limit { get; private set; }
        public List<Statement> StatementList { get; private set; }
        public CreditCard(string cardName, Currency currency, double limit)
        {
            this.Name = cardName;
            this.Currency = currency;
            this.Limit = limit;
            this.CurrentStatement = new CardStatement(currency, DateTime.Today, limit, 0);
            this.StatementList = new List<Statement>();
        }
        public void SetNewLimit(double NewLimit)
        {
            this.Limit = NewLimit;
        }
        public override double GetBalance()
        {
            return this.CurrentStatement.GetBalance();
        }
        public void NewMonth()
        {
            Statement newStatement = new CardStatement(Currency, DateTime.Now, this.Limit, this.GetBalance());
            StatementList.Add(this.CurrentStatement);
            this.CurrentStatement = newStatement;
        }
    }
}