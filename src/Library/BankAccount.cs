//Representa las cuentas bancarias que tiene el usuario
//Es un Creator de BankAccountStatement porque los crea y almacena.
using System;
using System.Collections.Generic;

namespace Library
{
    public class BankAccount : PaymentMethod
    {
        public List<BankAccountStatement> StatementList {get; private set;}
        public BankAccountStatement CurrentStatement { get; private set; }
        private string BankName {get ;}

        public BankAccount(String BankName, Currency currency, DateTime date)
        {
            this.BankName = BankName;
            this.StatementList = new List<BankAccountStatement>();
            this.CurrentStatement = new BankAccountStatement(currency, date, 0);
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