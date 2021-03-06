using System;
//Representa una reducción de los fondos en una cuenta bancaria, o un gasto a crédito en una tarjeta
//Es un subtipo de Transactions, esto permite que por el principio LSP, donde se espera un tipo Transactions, acepte un subtipo Expense
namespace Library
{
    public class Expense : Transactions
    {
        public ExpenseType ExpenseType { get; private set; }
        public Expense(String concept, double ammount, Currency currency)
        {
            this.Concept = concept;
            this.Ammount = ammount;
            this.Currency = currency;
            this.ExpenseType = null;
            this.IsPositive = false;
        }
        public void ChangeExpenseType(ExpenseType name)
        {
            this.ExpenseType = name;
        }
    }
}