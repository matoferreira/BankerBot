using System;
using NUnit.Framework;
using Library;
using System.Linq;

namespace Library.Test
{
    public class CreditCardTest
    {
        private CreditCard creditCard;
        private Currency currency;
        private double limit;

        [SetUp]
        public void Setup()
        {
            currency = new Currency("USD");
            limit = 5000;
            creditCard = new CreditCard("Hipermas", currency, limit);
            creditCard.CurrentStatement.AddTransaction("surtido", 2000, currency, false);

        }

        [Test]
        public void SetNewLimitTest()
        {
            creditCard.SetNewLimit(10000);
            Assert.AreEqual(10000,creditCard.Limit);
        }

        [Test]
        public void GetBalanceTest()
        {
            Assert.AreEqual(2000,creditCard.GetBalance());
        }


        [Test]
        public void NewMonthTest()
        {
            double statementcounter = creditCard.StatementList.Count();
            creditCard.NewMonth();
            Assert.AreEqual(statementcounter+1, creditCard.StatementList.Count());
        }
    }
}