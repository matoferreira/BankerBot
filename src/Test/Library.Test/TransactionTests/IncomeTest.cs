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
	            // Insertá tu código de inicialización aquí
                currency = new Currency("USD");
	            income = new Income("Prueba1",1500,currency);
				bank = new BankAccount("santander", currency);
	          
	        }
	
	        [Test]
	        public void TestConcept() // Cambiá el nombre para indicar qué estás probando
	        {
	            string a = "Prueba1";
	            	
	            Assert.AreEqual(income.Concept, a);
	        }
	
	           [Test]
	        public void TestTestAmmount() 
	        {
	            double a = 1500;
	            	
	            Assert.AreEqual(income.Ammount, a);
	        }

            
	        [Test]
	        public void TestTestCurrency() 
	        {
	            string a = "USD";
	            	
	            Assert.AreEqual(income.Currency.Name, a);
	        }
			[Test]
	        public void TestIncome() 
	        {
	            bank.CurrentStatement.AddTransaction(income);
	            Assert.AreEqual(income.Ammount, bank.GetBalance());
	        }
            
	    }

	}

