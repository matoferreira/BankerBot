using System;
using System.Collections.Generic;

//Representa las tarjetas de crédito que tiene el usuario
//Es un Creator de CreditCardStatement porque los crea y almacena.

namespace Library
{
    public class CreditCard : PaymentMethod
    {
        public double Limit { get; private set; }
        public List<CardStatement> StatementList {get; private set;}
        public CardStatement CurrentStatement { get; protected set; }
        public CreditCard(Currency currency, DateTime date, double limit)
        {
            this.CurrentStatement = new CardStatement(currency, date, limit, 0);
            this.StatementList = new List<CardStatement>();
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