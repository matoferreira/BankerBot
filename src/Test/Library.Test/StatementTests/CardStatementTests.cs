using NUnit.Framework;
using System;
using System.Collections.Generic;

	namespace Library.Test
	{
	    public class CardStatementTests
	    {
			private CardStatement statement;
	        private Income income;
            private Currency currency;
	
	        [SetUp]
	        public void Setup()
	        {
	            currency = new Currency("USD");
				statement = new CardStatement(currency, DateTime.Now, 100000, 0);
	          
	        }

			[Test]
	        public void TestGetBalance()
	        {
				statement.AddTransaction("depósito", 15000, currency, true);   	
	            Assert.AreEqual(-15000, statement.GetBalance());
	        }

			[Test]
	        public void TestTransactionBiggerThanLimit()
	        {
				Assert.That(statement.AddTransaction("compra",500000000, currency, false),Is.False);		
	        }
			[Test]
	        public void TestCalculatePaymentAmmount()
	        {
				statement.AddTransaction("depósito", 15000, currency, true); 
				Assert.AreEqual(-15000, statement.CalculatePaymentAmmount());		
	        }
			[Test]
			public void TestMakePayment()
	        {
				statement.AddTransaction("depósito", 15000, currency, true); 
				statement.MakePayment(10000);
				Assert.AreEqual(-5000, statement.GetBalance());		
	        }
	    }

	}

