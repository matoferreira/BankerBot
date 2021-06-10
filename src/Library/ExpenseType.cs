using System;
using System.Collections.Generic;

namespace Library
{
    public class ExpenseType
    {
        public string name;
        public List<Expense> expenses { get; private set; }


        public ExpenseType (string name ){

        }

        public double CalculateTotal(List<Expense> expenses){
            return 0;
        }

         public void AccumulateExpenses(List<Expense> expenses){
            
        }

    }
}