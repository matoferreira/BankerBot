using System;


namespace Library
{
    public class Expense : Transactions
    {
        public ExpenseType expenseType { get; private set; }
        public double ammount { get; private set; }
        public string Concept { get; private set; } 
        public Expense (String concept, double ammount, Currency currency, ExpenseType expenseType)
        {

        }
    }
}