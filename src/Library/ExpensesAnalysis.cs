using System;
using System.Collections.Generic;
//Esta clase es la encargada de realizar los analisis de los gastos por tipo
namespace Library
{    public class ExpenseAnalysis
    {
        public string name;

        ExpenseType expenseType;
        public List<Expense> Expenses;

        public double TotalByType = 0;

        public ExpenseAnalysis (string name , ExpenseType expenseType){
            this.name = name;
            
        }

        public double CalculateTotalByType(List<Expense> expenses, ExpenseType expenseType){
            foreach (Expense expense in expenses){
                if (typeof(Expense).IsInstanceOfType(expenseType))
                    TotalByType+= expense.Ammount;
            }

            return TotalByType;
        }   

         public void AccumulateExpensesByType(List<Expense> expenses, ExpenseType expenseType){
            foreach (Expense expense in expenses)
            if (typeof(Expense).IsInstanceOfType(expenseType))
           {
               Expenses.Add(expense);
           }
        }



    }
}