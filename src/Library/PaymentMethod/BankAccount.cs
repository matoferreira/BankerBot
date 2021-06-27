//Representa las cuentas bancarias que tiene el usuario
//Es un Creator de BankAccountStatement porque los crea y almacena.
using System;
using System.Collections.Generic;

namespace Library
{
    public class BankAccount : PaymentMethod
    {
        public List<Statement> StatementList {get; private set;}
        //public BankAccountStatement CurrentStatement {get; protected set;}

        public BankAccount(String BankName, Currency currency)
        {
            this.Name = BankName;
            this.Currency = currency;
            this.StatementList = new List<Statement>();
            this.CurrentStatement = new BankAccountStatement(currency, DateTime.Today, 0);
        }
        public override double GetBalance()
        {
            this.NotifyObservers();
            return this.CurrentStatement.GetBalance();
        } 
        public void NewMonth()
        {
            Statement newStatement = new BankAccountStatement(Currency, DateTime.Now, this.GetBalance());
            StatementList.Add(this.CurrentStatement);
            this.CurrentStatement = newStatement;
        }

    }
}