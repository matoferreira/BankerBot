using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Library.Test
{
    public class HighSpendingAlertTests
    {
        private UserProfile profile = new UserProfile();
        private Currency currency = new Currency("USD");
        private CreditCard tarjeta; 

        [SetUp]
        public void Setup()
        {
            profile.Alerts.Find(item => typeof(HighSpendingAlert).IsInstanceOfType(item)).ChangeLevel(1000);
            tarjeta = new CreditCard("Santander", currency, 1000000);
            profile.AddPaymentMethod(tarjeta);
            //tarjeta.CurrentStatement.AddTransaction(new Income("prueba", 2000, currency));
            tarjeta.CurrentStatement.AddTransaction(new Expense("prueba", 1900, currency, new ExpenseType("prueba")));
            profile.Update();
        }

        [Test]
        public void TestLevel()
        {
            Assert.AreEqual(1000, profile.Alerts.Find(item => typeof(HighSpendingAlert).IsInstanceOfType(item)).Level);
        }
        [Test]
        public void TestTurnoOn()
        {
            Assert.That(profile.Alerts.Find(item => typeof(HighSpendingAlert).IsInstanceOfType(item)).IsOn, Is.True);
        }
    }
}