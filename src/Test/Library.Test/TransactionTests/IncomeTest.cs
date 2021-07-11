using NUnit.Framework;

	namespace Library.Test
	{
	    public class IncomeTests
	    {
	        private Income income;

            private Currency currency;
			private BankAccount bank;
	
	        [SetUp]
	        public void Setup()
	        {
                currency = new Currency("USD");
	            income = new Income("Prueba1",1500,currency);
				bank = new BankAccount("santander", currency);
	          
	        }
	
	        [Test]
	        public void TestConcept()
	        {
	            string a = "Prueba1";
	            	
	            Assert.AreEqual(income.Concept, a);
	        }
	
	           [Test]
	        public void TestAmmount() 
	        {
	            double a = 1500;
	            	
	            Assert.AreEqual(income.Ammount, a);
	        }

            
	        [Test]
	        public void TestCurrency() 
	        {
	            string a = "USD";
	            	
	            Assert.AreEqual(income.Currency.Name, a);
	        }
			[Test]
	        public void TestIncome() 
	        {
	            bank.CurrentStatement.AddTransaction("prueba1",1500, currency, true);
	            Assert.AreEqual(income.Ammount, bank.GetBalance());
	        }
            
	    }

	}

