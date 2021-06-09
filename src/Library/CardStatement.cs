//Esta es una subclase de Statement, utilizada por la tarjeta de Crédito para almacenar sus movimientos de dinero.
//Es una especialización de Statement, que al ser concreta puede instanciarse.
//tiene una fecha asociada, un nuevo cardStatement se creará a principios de cada mes, comenzará con el balance final del mes anterior
//como su balance inicial.
//Tendrá un limite de crédito asociado, transacciones que superen este límite no serán aceptadas

using System;
using System.Collections.Generic;

namespace Library
{
    public class CardStatement : Statement
    {
        public double limit { get; private set; }
        public List<Transactions> transactions { get; private set; }
        public CardStatement(Currency currency, DateTime date, double limit, double lastbalance)
        {
            this.Currency = currency;
            this.Date = date;
            this.limit = limit;
            this.transactions = new List<Transactions>();
            this.Balance = lastbalance;
        }
        public override bool AddTransaction()
        {
            return true;
        }
        public override void RemoveTransaction()
        {

        }
        public override double GetBalance()
        {
            return 0;
        }
        public double CalculatePaymentAmmount()
        {
            return 0;
        }
    }
}