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
        public double Limit { get; private set; }
        private double previousBalance;
        public CardStatement(Currency currency, DateTime date, double limit, double lastbalance)
        {
            this.Currency = currency;
            this.Date = date;
            this.Limit = limit;
            this.previousBalance = lastbalance;
            this.Balance = 0;
        }
        public override bool AddTransaction(Transactions transaction) //Si la transaccion supera el límite, devuelve false
        {
            if (typeof(Income).IsInstanceOfType(transaction))
            {
                if (transaction.Ammount <= this.Limit)
                {
                    Transactions.Add(transaction);
                    this.Balance = this.Balance + transaction.Ammount;
                    this.Limit = this.Limit - transaction.Ammount;                  
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Transactions.Add(transaction);
                this.Balance = this.Balance - transaction.Ammount;
                this.Limit = this.Limit + transaction.Ammount;
            }
            return true;
        }
        public override double GetBalance()
        {
            double newbalance = 0 + previousBalance;
            foreach (Transactions transaction in Transactions)
            {
                if (typeof(Income).IsInstanceOfType(transaction))
                {
                    newbalance = newbalance + transaction.Ammount;
                }
                else
                {
                    newbalance = newbalance - transaction.Ammount;
                }
            } 
            this.Balance = newbalance;
            return newbalance;
        }
        public double CalculatePaymentAmmount()
        {
            double newpayment = 0;
            foreach (Transactions transaction in Transactions)
            {
                if (typeof(Income).IsInstanceOfType(transaction))
                {
                    newpayment = newpayment + transaction.Ammount;
                }
                else
                {
                    newpayment = newpayment - transaction.Ammount;
                }
            } 
            return newpayment;
        }
        public void MakePayment(double ammount)
        {
            this.Limit = this.Limit + ammount;
            this.AddTransaction(new Expense("Pago de Saldo de tarjeta", ammount, this.Currency, new ExpenseType("Pago")));
        }
    }
}