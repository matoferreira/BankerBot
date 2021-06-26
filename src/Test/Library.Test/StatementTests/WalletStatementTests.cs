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
	            income = new Income("Prueba1",15000,currency);
	          
	        }
	
	        [Test]
	        public void TestAddtransaction()
	        {
				statement.AddTransaction(income);           	
	            Assert.That(statement.Transactions, Contains.Item(income));
	        }
			[Test]
	        public void TestGetBalance()
	        {
				statement.AddTransaction(income);           	
	            Assert.AreEqual(15000, statement.GetBalance());
	        }
	
	        [Test]
	        public void TestAddSeveralTransactions() 
	        {
	            statement.AddTransaction(income);
	            statement.AddTransaction(income);
				statement.AddTransaction(income);            	
	            Assert.AreEqual(15000*3, statement.GetBalance());
	        }

            
	        [Test]
	        public void TestRemovetransaction()
	        {
				statement.AddTransaction(income);
				statement.RemoveTransaction(income);	
	            Assert.That(statement.Transactions, !Contains.Item(income));
	        }

            [Test]
	        public void TestDifferentTransactions()
	        {
				statement.AddTransaction(income);
				statement.AddTransaction(new Expense("compra",5000, currency, new ExpenseType("compra")));	
	            Assert.AreEqual(10000, statement.GetBalance());
	        }

	    }

	}

