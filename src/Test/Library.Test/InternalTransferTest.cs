using NUnit.Framework;
using System;

	namespace Library.Test
	{
	    public class InternalTransferTest
	    {
            private PaymentMethod Destination;

            private Currency currency;

            private ExpenseType expenseType;

            private InternalTransfer internalTransfer1;
	
	        [SetUp]
	        public void Setup()
	        {
                currency = new Currency("UYU");
	            Destination = new BankAccount("MiBanco", currency);
                InternalTransfer internalTransfer1 = new InternalTransfer ("Aguinaldo",20000, currency, Destination);
	          
	        }
	
	        [Test]
	        public void TestDestinationAmmount()
	        {
	            double a = 20000;
	            	
	            Assert.AreEqual(Destination.GetBalance(), a);
	        }
	

            
	    }

	}