//Representa las cuentas bancarias que tiene el usuario
//Es un Creator de BankAccountStatement porque los crea y almacena.
using System;
using System.Collections.Generic;

namespace Library
{
    public class BankAccount : PaymentMethod
    {
        public List<BankAccountStatement> StatementList {get; private set;}
        public string BankName { get; private set; }
        public new BankAccountStatement CurrentStatement {get; protected set;}

        public BankAccount(String BankName, Currency currency)
        {
            this.BankName = BankName;
            this.StatementList = new List<BankAccountStatement>();
            this.CurrentStatement = new BankAccountStatement(currency, DateTime.Today, 0);
        }
        public override double GetBalance()
        {
            return CurrentStatement.GetBalance();
        } 
        public void NewMonth()
        {
            BankAccountStatement newStatement = new BankAccountStatement(Currency, DateTime.Now, this.GetBalance());
            StatementList.Add(this.CurrentStatement);
            this.CurrentStatement = newStatement;
        }

    }
}