using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Library.Test
{
    public class HighSpendingAlertTests
    {
        private UserProfile profile = new UserProfile();
        private Currency currency = new Currency("USD");
        private BankAccount bank; 

        [SetUp]
        public void Setup()
        {
            profile.Alerts.Find(item => typeof(HighSpendingAlert).IsInstanceOfType(item)).ChangeLevel(1000);
            bank = new BankAccount("Santander", currency);
            profile.AddPaymentMethod(bank);
            bank.CurrentStatement.AddTransaction(new Income("prueba", 2000, currency));
        }

        [Test]
        public void TestLevel()
        {
            Assert.AreEqual(1000, profile.Alerts.Find(item => typeof(HighSpendingAlert).IsInstanceOfType(item)).Level);
            //Assert.AreEqual(profile.PaymentMethods[0].GetBalance(), bank.GetBalance());
        }
        [Test]
        public void TestTurnoOn()
        {
            Assert.That(profile.Alerts.Find(item => typeof(HighSpendingAlert).IsInstanceOfType(item)).IsOn, Is.True);
        }
    }
}