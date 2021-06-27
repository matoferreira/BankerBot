//Statement es una clase abstracta que lleva el control del flujo de fondos en los diferentes productos que maneja el Bot (Billetera, Tarjeta de crédito o cuenta Bancaria)
//Las subclases de Statement serán específicas para cada uno de esos productos (Por ejemplo la tarjeta de crédito tendrá un límite de crédito asociado)  
//Tiene la responsabilidad de acumular todos los movimientos de dinero que entran o salen de cada una de los PaymentMethod
//Por el patrón Creator, Statement es quien agrega o elimina las transacciones que se hacen, ya que esta compuesto por una lista de ellas
//y las utiliza estrechamente para calcular el balance de la cuenta  
//Por SRP, la unica razón de cambio de Statement son AddTransaction y RemoveTransaction, que agregan y quitan transacciones de la lista, respectivamente
using System;
using System.Collections.Generic;

namespace Library
{
    public abstract class Statement
    {
        public Currency Currency { get; protected set; }
        public DateTime Date { get; protected set; }
        public double Balance { get; protected set; }
        public List<Transactions> Transactions { get; protected set;}
        public Statement()
        {
            this.Transactions = new List<Transactions>();
            this.Balance = 0;
        }
        public virtual bool AddTransaction(Transactions transaction)
        {
            Transactions.Add(transaction);
            if (typeof(Income).IsInstanceOfType(transaction))
            {
                this.Balance = this.Balance + transaction.Ammount;
            }
            else
            {
                this.Balance = this.Balance - transaction.Ammount;
            }
            return true;
        }
        public virtual void RemoveTransaction(Transactions transaction)
        {
            if (Transactions.Contains(transaction))
            {
                Transactions.Remove(transaction);
            }
        }
        public virtual void ChangeBalance(double newBalance)
        {
            this.Balance = newBalance;
        }
        public virtual double GetBalance()
        {
            return this.Balance;
        }
    }
}