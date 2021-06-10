using System;

//Es un subtipo de Transactions, esto permite que por el principio LSP, donde se espera un tipo Transactions, acepte un subtipo Expense
namespace Library
{
    public class Expense : Transactions
    {
        public ExpenseType expenseType { get; private set; }
        public double Ammount { get; private set; }
        public string Concept { get; private set; } 
        public Expense (String concept, double ammount, Currency currency, ExpenseType expenseType)
        {

        }
    }
}