using NUnit.Framework;
using System.Collections.Generic;

	namespace Library.Test
	{
	    public class WalletStatementTests
	    {
			private WalletStatement statement;
	        private Income income;

            private Currency currency;
	
	        [SetUp]
	        public void Setup()
	        {
	            currency = new Currency("USD");
				statement = new WalletStatement(currency);	          
	        }
			
			[Test]
	        public void TestGetBalance()
	        {
				statement.AddTransaction("sueldo", 15000, currency, true);        	
	            Assert.AreEqual(15000, statement.GetBalance());
	        }
		}
	}