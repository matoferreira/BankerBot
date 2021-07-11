using NUnit.Framework;
using System;
using System.Collections.Generic;
using Library;

	namespace Library.Test
	{
	    public class ExpenseAnalysisTest

		{  

			private ExpenseType expenseType1;
			private ExpenseType expenseType2;
			private BankAccount bankAccount10;
			private BankAccount bankAccount20;
			private Currency currency1;
			private List<PaymentMethod> payments1;
			private List<ExpenseType> expenseList;
			private ExpenseAnalysis expenseAnalysis2;
            [SetUp]
        	public void Setup()
        {
            currency1 = new Currency("USD");
            bankAccount10 = new BankAccount("Cuenta1", currency1);
			bankAccount20 = new BankAccount("Cuenta2", currency1);
			payments1 = new List<PaymentMethod>();
			payments1.Add(bankAccount10);
			payments1.Add(bankAccount20);
			expenseList = new List<ExpenseType>();
			expenseType1 = new ExpenseType("ropa");
			expenseType2 = new ExpenseType("Alimentos");
			expenseList.Add(expenseType1);
			expenseList.Add(expenseType2);
			bankAccount10.CurrentStatement.AddTransaction("camisa", 1000, currency1, false);
			bankAccount20.CurrentStatement.AddTransaction("fideos", 2000, currency1, false);
			bankAccount10.CurrentStatement.AddTransaction("pantalon", 500, currency1, false);
			bankAccount20.CurrentStatement.AddTransaction("alfajor", 600, currency1, false);
			expenseAnalysis2 = new ExpenseAnalysis();

			Console.WriteLine($"{expenseAnalysis2.CalculateTotalByType(payments1, expenseList)}");
            
        }

        [Test]
        public void CalculateTotalByTypeTest()
        {
           string a="Gastos Mensuales:\n Ropa: 1500#Gastos Mensuales:\n Alimentos: 2600#";
		   Assert.AreEqual(a,expenseAnalysis2.CalculateTotalByType(payments1, expenseList));
		  
        }
		}
	}

