using NUnit.Framework;
using System;

	namespace Library.Test
	{
	    public class InternalTransferTest
	    {
	        private DateTime DateTime;
            private PaymentMethod Destination;

            private Currency currency;

            private ExpenseType expenseType;

            private InternalTransfer internalTransfer1;
	
	        [SetUp]
	        public void Setup()
	        {
                DateTime date3 = DateTime.Today;
                currency = new Currency("UYU");
	            Destination = new BankAccount("MiBanco", currency, date3);
                InternalTransfer internalTransfer1 = new InternalTransfer ("Aguinaldo",20000, currency, Destination);
	          
	        }
	
	        [Test]
	        public void TestAmmount()
	        {
	            double a = 20000;
	            	
	            Assert.AreEqual(Destination.GetBalance(), a);
	        }
	
	           [Test]
	        public void TestTestAmmount() 
	        {
	         //  double a = 55;
	            	
	         //   Assert.AreEqual(expense.Ammount, a);
	        }

            
	           [Test]
	        public void TestTestCurrency() 
	        {
	           // string a = "UYU";
	            	
	           // Assert.AreEqual(expense.Currency.Name, a);
	        }

            	           [Test]
	        public void TestExpenseType() 
	        {
	           // string a = "Alimentos";
	            	
	           // Assert.AreEqual(expenseType.Name, a);
	        }
            
	    }

	}