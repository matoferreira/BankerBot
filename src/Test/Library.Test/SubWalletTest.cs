using System;
using NUnit.Framework;
using Library;
using System.Linq;

namespace Library.Test
{
    public class SubWalletTest
    {
        private SubWallet subWallet;
        private Currency currency;
        [SetUp]
        public void Setup()
        {
            currency = new Currency("USD");
            subWallet = new SubWallet("USD wallet", currency);
            subWallet.Statement.AddTransaction(new Income("sueldo", 3000, currency));
        }

        [Test]
        public void AddATransactionTest()
        {
            Assert.AreEqual(3000,subWallet.Statement.GetBalance());
        }
    }
}