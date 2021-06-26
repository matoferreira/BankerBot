using NUnit.Framework;
using System;
using System.Collections.Generic;
using Library;

	namespace Library.Test
	{
	    public class ExpenseTypeTest
	    {       
            private string Name;
			private Currency currency;	
			private ExpenseType expenseType1;
			private ExpenseType expenseType2; 

			private BankAccount MyAccount1;

			private BankAccount MyAccount2;

			private List<PaymentMethod> MisCuentas;

			
			private double Ammount;
	        [SetUp]
	        public void Setup()
	        {	
				DateTime date3 = DateTime.Today;
	           	ExpenseType expenseType1 = new ExpenseType ("Alimentos");
				ExpenseType expenseType2 = new ExpenseType ("Vestimenta");
				currency = new Currency("USD");
				BankAccount MyAccount1 = new BankAccount("MiBanco1", currency,date3);
				BankAccount MyAccount2 = new BankAccount("MiBanco2", currency,date3);

				MyAccount1.CurrentStatement.AddTransaction(new Income("sueldo", 1000, currency));
				//MyAccount1.CurrentStatement.AddTransaction(new Expense("Gasto", 100,currency,expenseType1));
				//MyAccount1.CurrentStatement.AddTransaction(new Expense("Gasto", 200,currency,expenseType2));
				MyAccount2.CurrentStatement.AddTransaction(new Expense("Gasto", 300,currency,expenseType1));
				MyAccount2.CurrentStatement.AddTransaction(new Expense("Gasto", 100,currency,expenseType2));

				List<PaymentMethod> MisCuentas = new List<PaymentMethod>();
				
				MisCuentas.Add(MyAccount1);
				MisCuentas.Add(MyAccount2);		          
	                 
	        }
	
	       	[Test]
	        public void TestCalculateTotal() 
	        {
	            double a = 400;
	            Assert.AreEqual(a, expenseType1.CalculateTotal(MisCuentas));

				/*está dando error este test*/
	        }

			[Test]
			public void TestMiCuenta1()
	        {
	               	
	             Assert.AreEqual(1000,MyAccount1.GetBalance());
	        }
	


            
	    }

	}

