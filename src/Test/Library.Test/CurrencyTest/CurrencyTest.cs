using System;
using NUnit.Framework;
using Library;

namespace Library.Test
{
    public class CurrencyTest
    {
        private Currency currency;
        private IExchange Exchanger = new CurrencyExchangeAPI();
        [SetUp]
        public void Setup()
        {
            currency = new Currency("USD");
        }

        [Test]
        public void ConvertTest()
        {
            Assert.AreEqual(500,currency.Convert(500));
        }
    }
}