using System;
using System.Collections.Generic;

namespace Library
{
    public class ExpenseType
    {
        public string Name { get; private set; }
        public List<Expense> expenses { get; private set; }


        public ExpenseType (string name )
        {

        }
      
        public double CalculateTotaByType(List<Expense> expenses)
        {
            return 0;
        }

         public void AccumulateExpensesByType(List<Expense> expenses)
         {  
           
         }

    }
}