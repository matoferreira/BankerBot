using System;
using System.Collections.Generic;
//Esta clase es la encargada de realizar los analisis de los gastos por tipo
//Recibe una lista con paymentMethods y los categoriza segun su tipo de gasto(Expensetype)
//Devolviendo un string con cada ExpenseType y el total de gastos
//Con el siguiente formato: (ExpenseType),(Total)#, para su posterior uso por Telegram.
//Es un Singleton pues no tiene sentido que exista más de un objeto.
//Cumple con SRP pues su única razon de cambio es cuando se realiza un nuevo gasto en algún PaymentMethod
//Cuando esto ocurre, el UserInterface llama a este Singleton para que
//Actualice la string con los gastos agregados por tipo.
namespace Library
{
    public class ExpenseAnalysis
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
            string lista = "";
            this.GetExpenseTypes(payments);
            if (this.ExpenseTypes.Count >= 1)
            {
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
            }
            return lista;
        }
    }
}