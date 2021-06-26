using NUnit.Framework;
using System;
using System.Collections.Generic;
using Library;

	namespace Library.Test
	{
	    public class ExpenseTypeTests
	    {       
			private Currency currency;	
			private ExpenseType expenseType1;
			private ExpenseType expenseType2; 
			private DateTime date3;
			private BankAccount MyAccount1;

			private BankAccount MyAccount2;

			private List<PaymentMethod> MisCuentas;
	        [SetUp]
	        public void Setup()
	        {	
				date3 = DateTime.Today;
	           	expenseType1 = new ExpenseType ("Alimentos");
				expenseType2 = new ExpenseType ("Vestimenta");
				currency = new Currency("USD");
				MyAccount1 = new BankAccount("MiBanco1", currency, date3);
				MyAccount2 = new BankAccount("MiBanco2", currency, date3);
				MyAccount1.CurrentStatement.AddTransaction(new Income("sueldo", 1000, currency));
				MyAccount1.CurrentStatement.AddTransaction(new Expense("Gasto", 100,currency, expenseType1));
				MyAccount1.CurrentStatement.AddTransaction(new Expense("Gasto", 200,currency, expenseType2));
				MyAccount2.CurrentStatement.AddTransaction(new Expense("Gasto", 300, currency, expenseType1));
				MyAccount2.CurrentStatement.AddTransaction(new Expense("Gasto", 100, currency, expenseType2));
				MisCuentas = new List<PaymentMethod>();
				MisCuentas.Add(MyAccount1);
				MisCuentas.Add(MyAccount2);		          
	                 
	        }
	
	       	[Test]
	        public void TestCalculateTotal() 
	        {
	            Assert.AreEqual(400, expenseType1.CalculateTotal(MisCuentas));

				/*está dando error este test*/
	        }

			[Test]
			public void TestMiCuenta1()
	        {
	               	
	             Assert.AreEqual(700, MyAccount1.GetBalance());
	        }
	


            
	    }

	}

