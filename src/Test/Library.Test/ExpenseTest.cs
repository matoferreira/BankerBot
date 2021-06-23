using NUnit.Framework;

	namespace Library.Test
	{
	    public class ExpenseTests
	    {
	        private Expense expense;

            private Currency currency;

            private ExpenseType expenseType;
	
	        [SetUp]
	        public void Setup()
	        {
	           
                expenseType = new ExpenseType ("Alimentos");
                currency = new Currency("UYU");
	            expense = new Expense("Alfajor", 55,currency,expenseType);
	          
	        }
	
	        [Test]
	        public void TestConcept() 
	        {
	            string a = "Alfajor";
	            	
	            Assert.AreEqual(expense.Concept, a);
	        }
	
	           [Test]
	        public void TestTestAmmount() 
	        {
	            double a = 55;
	            	
	            Assert.AreEqual(expense.Ammount, a);
	        }

            
	           [Test]
	        public void TestTestCurrency() 
	        {
	            string a = "UYU";
	            	
	            Assert.AreEqual(expense.Currency.Name, a);
	        }

            	           [Test]
	        public void TestExpenseType() 
	        {
	            string a = "Alimentos";
	            	
	            Assert.AreEqual(expense.expenseType.Name, a);
	        }
            
	    }

	}