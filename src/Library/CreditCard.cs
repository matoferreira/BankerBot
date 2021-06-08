using System;

namespace Library
{
    public class CreditCard
    {
        public Currency Currency {get ; private set;}
        public double Limit {get ; private set;}
        public double Balance {get ; private set;}
        public CardStatement CurrentStatement {get ; private set;}
        public List<CardStatement> StatementList {private get; private set;}
        //falta agregar constructor
        public string GetCurrency()
        {
            return Currency;
        }
        public double GetLimit()
        {
            return Limit;
        }
    }
}