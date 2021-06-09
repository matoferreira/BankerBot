//Esta es una subclase de Statement, utilizada por la cuenta bancaria para almacenar sus movimientos de dinero.
//Es una especialización de Statement, que al ser concreta puede instanciarse.
//tiene una fecha asociada, un nuevo bankaccountStatement se creará a principios de cada mes, comenzará con el balance final del mes anterior
//como su balance inicial.

using System;
using System.Collections.Generic;

namespace Library
{
    public class BankAccountStatement : Statement
    {
        public List<Transactions> transactions { get; private set; }
        public BankAccountStatement(Currency currency, DateTime date, double lastbalance)
        {
            this.Currency = currency;
            this.Date = date;
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
    }
}