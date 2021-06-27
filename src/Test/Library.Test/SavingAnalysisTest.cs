using NUnit.Framework;
using System;
using System.Collections.Generic;
using Library;

	namespace Library.Test
	{
	    public class SavingAnalysisTest

		{  

			private ExpenseType expenseType1;
			private ExpenseType expenseType2;
			private BankAccount bankAccount1;
			private BankAccount bankAccount2;
			private Currency currency;
			private List<PaymentMethod> savingsAccounts;
            private SavingsAnalysis mySavingsAnalysis;
            [SetUp]
        	public void Setup()
        {
            currency = new Currency("USD");
            bankAccount1 = new BankAccount("Cuenta1", currency);
			//bankAccount2 = new BankAccount("Cuenta2", currency);
			savingsAccounts = new List<PaymentMethod>();
			savingsAccounts.Add(bankAccount1);
			//savingsAccounts.Add(bankAccount2);
			expenseType1 = new ExpenseType("Ropa");
			expenseType2 = new ExpenseType("Alimentos");
            bankAccount1.CurrentStatement.AddTransaction(new Income("Sueldo", 100000, currency));
			//bankAccount2.CurrentStatement.AddTransaction(new Income("Aguinaldo", 20000, currency));
			bankAccount1.CurrentStatement.AddTransaction(new Expense("camisa", 1000, currency,expenseType1));
			//bankAccount2.CurrentStatement.AddTransaction(new Expense("camisa", 2000, currency,expenseType1));
			bankAccount1.CurrentStatement.AddTransaction(new Expense("alfajor", 500, currency,expenseType2));
			//bankAccount2.CurrentStatement.AddTransaction(new Expense("alfajor", 600, currency,expenseType2));
            mySavingsAnalysis = new SavingsAnalysis();

            
        }

        [Test]
        public void CalculateSavingTest()
        {
           string a = "98500 USD en cuenta bancaria Cuenta1#Ahorro total: 98500 Pesos";
           Assert.AreEqual(a,mySavingsAnalysis.AnalyseSavings(savingsAccounts));
		  
        }

		}
	}