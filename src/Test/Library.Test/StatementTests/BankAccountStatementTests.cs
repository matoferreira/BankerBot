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
			[Test]
	        public void TestLastBalance()
	        {
				BankAccountStatement statement2 = new BankAccountStatement(currency, DateTime.Now, 1000);
				statement2.AddTransaction(income);	
	            Assert.AreEqual(16000, statement2.GetBalance());
	        }
	    }

	}

