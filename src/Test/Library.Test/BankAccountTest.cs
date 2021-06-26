using System;
using NUnit.Framework;
using Library;
using System.Linq;

namespace Library.Test
{
    public class BankAccountTest
    {
        private BankAccount bankAccount;
        private Currency currency;
        [SetUp]
        public void Setup()
        {
            currency = new Currency("USD");
            bankAccount = new BankAccount("Santander", currency, DateTime.Now);
            bankAccount.CurrentStatement.AddTransaction(new Income("sueldo", 1000, currency));
        }

        [Test]
        public void GetBalanceTest()
        {
            Assert.AreEqual(1000,bankAccount.GetBalance());
        }

        [Test]
        public void NewMonthTest()
        {
            double statementcounter = bankAccount.StatementList.Count();
            bankAccount.NewMonth();
            Assert.AreEqual(statementcounter+1, bankAccount.StatementList.Count());
        }
    }
}