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
			private BankAccount bankAccount1;
			private BankAccount bankAccount2;
			private Currency currency;
			private List<PaymentMethod> payments;
			private ExpenseAnalysis expenseAnalysis1;
            [SetUp]
        	public void Setup()
        {
            currency = new Currency("USD");
            bankAccount1 = new BankAccount("Cuenta1", currency);
			bankAccount2 = new BankAccount("Cuenta2", currency);
			payments = new List<PaymentMethod>();
			payments.Add(bankAccount1);
			payments.Add(bankAccount2);
			expenseType1 = new ExpenseType("Ropa");
			expenseType2 = new ExpenseType("Alimentos");
			bankAccount1.CurrentStatement.AddTransaction(new Expense("camisa", 1000, currency,expenseType1));
			bankAccount2.CurrentStatement.AddTransaction(new Expense("camisa", 2000, currency,expenseType1));
			bankAccount1.CurrentStatement.AddTransaction(new Expense("alfajor", 500, currency,expenseType2));
			bankAccount2.CurrentStatement.AddTransaction(new Expense("alfajor", 600, currency,expenseType2));
			expenseAnalysis1 = new ExpenseAnalysis();

			Console.WriteLine($"{expenseAnalysis1.CalculateTotalByType(payments)}");
            
        }

        [Test]
        public void CalculateTotalByTypeTest()
        {
           Assert.AreEqual(3000,3000,$"{expenseAnalysis1.CalculateTotalByType(payments)}");
		  // Console.WriteLine($"{expenseAnalysis1.CalculateTotalByType(payments)}");
        }

		}
	}

