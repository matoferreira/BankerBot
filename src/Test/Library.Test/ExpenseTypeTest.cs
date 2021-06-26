using NUnit.Framework;
using System;
using System.Collections.Generic;

	namespace Library.Test
	{
	    public class ExpenseTypeTest
	    {       
            private string Name;
			private Currency currency;	
			private ExpenseType expenseType1;
			private ExpenseType expenseType2; 

			private PaymentMethod MyAccount1;

			private PaymentMethod MyAccount2;

			private List<PaymentMethod> MisCuentas;

			
			private double Ammount;
	        [SetUp]
	        public void Setup()
	        {	
				DateTime date3 = DateTime.Today;
	           	ExpenseType expenseType1 = new ExpenseType ("Alimentos");
				ExpenseType expenseType2 = new ExpenseType ("Vestimenta");
				currency = new Currency("USD");
				PaymentMethod MyAccount1 = new BankAccount("MiBanco1", currency,date3);
				PaymentMethod MyAccount2 = new BankAccount("MiBanco2", currency,date3);

				Expense expense1 = new Expense("Gasto", 100,currency,expenseType1);
				Expense expense2 = new Expense("Gasto", 200,currency,expenseType2);
				Expense expense3 = new Expense("Gasto", 300,currency,expenseType1);
				Expense expense4 = new Expense("Gasto", 100,currency,expenseType2);
				
				MyAccount1.CurrentStatement.AddTransaction(expense1);
				MyAccount1.CurrentStatement.AddTransaction(expense2);
				MyAccount2.CurrentStatement.AddTransaction(expense3);
				MyAccount2.CurrentStatement.AddTransaction(expense4);

				List<PaymentMethod> MisCuentas = new List<PaymentMethod>();
				
				MisCuentas.Add(MyAccount1);
				MisCuentas.Add(MyAccount2);		          
	                 
	        }
	
	        [Test]
	        public void TestExpeseType()
	        {
	            	            	
	            //Assert.AreSame(expense.expenseType, expense3.expenseType);
	        }

			[Test]
	        public void TestCalculateTotal() 
	        {
	            double a = 400;
	            Assert.AreEqual(a, expenseType1.CalculateTotal(MisCuentas));
	        }
	


            
	    }

	}

