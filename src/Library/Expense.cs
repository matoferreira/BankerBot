using System;


namespace Library
{
    public class Expense : Transactions
    {
        public ExpenseType expenseType;
        private double ammount;
    
        private DateTime dateTime;

        public Expense (String concept, double ammount, Currency currency, ExpenseType expenseType)
        {

        }
    }
}