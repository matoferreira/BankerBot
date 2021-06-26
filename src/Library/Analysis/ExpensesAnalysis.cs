using System;
using System.Collections.Generic;
//Esta clase es la encargada de realizar los analisis de los gastos por tipo
namespace Library
{    public class ExpenseAnalysis
    {
        public List<ExpenseType> ExpenseTypes { get; private set; }

        public ExpenseAnalysis()
        {
            this.ExpenseTypes = new List<ExpenseType>();
        }
        public void GetExpenseTypes(List<PaymentMethod> payments)
        {
            foreach (PaymentMethod item in payments)
            {
                foreach (Transactions transaction in item.CurrentStatement.Transactions)
                {
                    if (typeof(Expense).IsInstanceOfType(transaction))
                    {
                        if (!ExpenseTypes.Contains(((Expense)transaction).ExpenseType))
                        {
                            ExpenseTypes.Add(((Expense)transaction).ExpenseType);
                        }
                    }
                }
            }
        }
        public string CalculateTotalByType(List<PaymentMethod> payments)
        {
            this.GetExpenseTypes(payments);
            string lista = "";
            foreach (ExpenseType expenseType in ExpenseTypes)
            {
                double total = 0;
                foreach (PaymentMethod item in payments)
                {
                    foreach (Transactions transaction in item.CurrentStatement.Transactions)
                    {
                        if (typeof(Expense).IsInstanceOfType(transaction) && ((Expense)transaction).ExpenseType == expenseType)
                        {
                        total = total + transaction.Ammount;
                        }
                    }
                }
                lista = lista + $"{expenseType},{total}#";
            }
            return lista;
        }
    }
}