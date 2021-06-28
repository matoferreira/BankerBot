using NUnit.Framework;
using System;
using System.Collections.Generic;
using Library;

	namespace Library.Test
	{
	    public class ExpenseAnalysisTest

		{  

			private ExpenseType expenseType3;
			private ExpenseType expenseType4;
			private BankAccount bankAccount10;
			private BankAccount bankAccount20;
			private Currency currency1;
			private List<PaymentMethod> payments1;
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
			expenseType3 = new ExpenseType("Ropa");
			expenseType4 = new ExpenseType("Alimentos");
			bankAccount10.CurrentStatement.AddTransaction(new Expense("camisa", 1000, currency1,expenseType3));
			bankAccount20.CurrentStatement.AddTransaction(new Expense("fideos", 2000, currency1,expenseType4));
			bankAccount10.CurrentStatement.AddTransaction(new Expense("pantalon", 500, currency1,expenseType3));
			bankAccount20.CurrentStatement.AddTransaction(new Expense("alfajor", 600, currency1,expenseType4));
			expenseAnalysis2 = new ExpenseAnalysis();

			Console.WriteLine(expenseAnalysis2.CalculateTotalByType(payments1));
            
        }

        [Test]
        public void CalculateTotalByTypeTest()
        {
           string a="Gastos Mensuales:\n Ropa: 1500#Gastos Mensuales:\n Alimentos: 2600#";
		   Assert.AreEqual(a,expenseAnalysis2.CalculateTotalByType(payments1));
		  
        }
		}
	}
