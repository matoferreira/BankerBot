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
			private Currency currency;
			private List<PaymentMethod> savingsAccounts;
            private SavingsAnalysis mySavingsAnalysis;
            [SetUp]
        	public void Setup()
        {
            currency = new Currency("USD");
            bankAccount1 = new BankAccount("Cuenta1", currency);
			savingsAccounts = new List<PaymentMethod>();
			savingsAccounts.Add(bankAccount1);
			expenseType1 = new ExpenseType("Ropa");
			expenseType2 = new ExpenseType("Alimentos");
            bankAccount1.CurrentStatement.AddTransaction("Sueldo", 100000, currency, true);
			bankAccount1.CurrentStatement.AddTransaction("camisa", 1000, currency, false);
			bankAccount1.CurrentStatement.AddTransaction("alfajor", 500, currency, false);;
            mySavingsAnalysis = new SavingsAnalysis();

            
        }

     [Test]
        public void CalculateSavingTest()
        {
           string a = "El ahorro mensual es:\n98500 USD en cuenta bancaria Cuenta1#Ahorro total: 98500 Pesos#";
           Assert.AreEqual(a,mySavingsAnalysis.AnalyseSavings(savingsAccounts));
		  
        }

		}
	}