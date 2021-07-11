using NUnit.Framework;
using System;
using System.Collections.Generic;

	namespace Library.Test
	{
	    public class BankAccountStatementTests
	    {
			private BankAccountStatement statement;
	        private Income income;
            private Currency currency;
	
	        [SetUp]
	        public void Setup()
	        {
	            currency = new Currency("USD");
				statement = new BankAccountStatement(currency, DateTime.Now ,0);
	          
	        }
			[Test]
	        public void TestGetBalance()
	        {
				statement.AddTransaction("sueldo", 15000, currency, true);        	
	            Assert.AreEqual(15000, statement.GetBalance());
	        }
		}

	}