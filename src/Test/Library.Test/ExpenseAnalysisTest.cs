using NUnit.Framework;
using System;
using System.Collections.Generic;
using Library;

	namespace Library.Test
	{
	    public class ExpenseAnalysisTest
	    {       
        private string name;
        private ExpenseType expenseType1;
        private ExpenseType expenseType2;
        private List<Expense> Expenses1;
        private double TotalByType = 0;
        private Currency currency1;

        private Expense expense1;
        private Expense expense2;
        private Expense expense3;
        private Expense expense4;

			
	        [SetUp]
	        public void Setup()
	        {	
				DateTime date3 = DateTime.Today;
	           	ExpenseType expenseType1 = new ExpenseType ("Alimentos");
				ExpenseType expenseType2 = new ExpenseType ("Vestimenta");
				currency1 = new Currency("USD");
				Expense expense1 = new Expense("Alfajor",10, currency1, expenseType1);
                Expense expense2 = new Expense("Chocolate",20, currency1, expenseType1);
                Expense expense3 = new Expense("Zapatos",100, currency1, expenseType2);
                Expense expense4 = new Expense("Camisa",200, currency1, expenseType2);

                List<Expense> Expenses1



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

