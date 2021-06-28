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
	            income = new Income("Prueba1", 15000, currency);
	          
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
	            Assert.AreEqual(-15000, statement.GetBalance());
	        }
	
	        [Test]
	        public void TestAddSeveralTransactions() 
	        {
	            statement.AddTransaction(income);
	            statement.AddTransaction(income);
				statement.AddTransaction(income);            	
	            Assert.AreEqual(-15000*3, statement.GetBalance());
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
	            Assert.AreEqual(-10000, statement.GetBalance());
	        }
			[Test]
	        public void TestLastBalance()
	        {
				CardStatement statement2 = new CardStatement(currency, DateTime.Now, 100000, -1000);
				statement2.AddTransaction(income);	
	            Assert.AreEqual(-16000, statement2.GetBalance());
	        }
			[Test]
	        public void TestTransactionBiggerThanLimit()
	        {
				Assert.That(statement.AddTransaction(new Expense("compra",500000000, currency, new ExpenseType("compra"))),Is.False);		
	        }
			[Test]
	        public void TestCalculatePaymentAmmount()
	        {
				statement.AddTransaction(income);
				Assert.AreEqual(-15000, statement.CalculatePaymentAmmount());		
	        }
			[Test]
			public void TestMakePayment()
	        {
				statement.AddTransaction(income);
				statement.MakePayment(10000);
				Assert.AreEqual(-5000, statement.GetBalance());		
	        }
	    }

	}

