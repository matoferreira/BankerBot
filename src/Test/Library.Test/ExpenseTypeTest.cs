using NUnit.Framework;
using System;
using System.Collections.Generic;
using Library;

	namespace Library.Test
	{
	    public class ExpenseTypeTest
	    {       
 			private string name;
        	private ExpenseType expenseType1;
        	private ExpenseType expenseType2;
        
			
	        [SetUp]
	        public void Setup()
	        {	
				
	           	expenseType1 = new ExpenseType ("Alimentos");
				expenseType2 = new ExpenseType ("Vestimenta");	          
	                 
	        }
	
	       	[Test]
	        public void TestExpensesTypes()
			{
	            string a = "Alimentos";
	            Assert.AreEqual(a, expenseType1.Name);

	        }

            
	    }

	}















