//Esta es una subclase de Statement, utilizada por la cuenta bancaria para almacenar sus movimientos de dinero.
//Es una especialización de Statement, que al ser concreta puede instanciarse.
//tiene una fecha asociada, un nuevo bankaccountStatement se creará a principios de cada mes, comenzará con el balance final del mes anterior
//como su balance inicial.
//Es el Expert en manejar las transacciones que entran y salen de la cuenta bancaria, y también es su CREATOR (Crea las 
//instancias porque es quien las agrega y las usa de forma cercana.)

using System;
using System.Collections.Generic;

namespace Library
{
    public class BankAccountStatement : Statement
    {
        private double previousBalance;
        public BankAccountStatement(Currency currency, DateTime date, double lastbalance)
        {
            this.Currency = currency;
            this.Date = date;
            this.previousBalance = lastbalance;
        }
        public override double GetBalance()
        {
            double newbalance = this.Balance + previousBalance;
            return newbalance;
        }
    }
}