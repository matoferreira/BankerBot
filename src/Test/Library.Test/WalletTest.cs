using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Library;
using System.Linq;

namespace Library.Test
{
    public class WalletTest
    {
        private Wallet wallet;
        private Currency currency1;
        private Currency currency2;
        private SubWallet subwallet1;
        private SubWallet subwallet2;
        [SetUp]
        public void Setup()
        {
            currency1 = new Currency("USD");
            currency2 = new Currency ("UYU");
            subwallet1 = new SubWallet("Dolares", currency1);
            subwallet2 = new SubWallet("Pesos", currency2);
            wallet = new Wallet(subwallet1);

        }

        [Test]
        public void AddSubWalletTest()
        {
            double subWalletCounter = wallet.SubWalletList.Count();
            wallet.AddSubWallet(subwallet2);
            Assert.AreEqual(subWalletCounter+1, wallet.SubWalletList.Count());
        }

        [Test]
        public void RemoveSubWallet()
        {
           double subWalletCounter = wallet.SubWalletList.Count();
           wallet.RemoveSubWallet(subwallet1);
           Assert.AreEqual(subWalletCounter-1, wallet.SubWalletList.Count());
        }
        
    }
}