using System;
using System.Collections.Generic;
//Esta clase es la encargada de realizar los analisis de los gastos por tipo
//Recibe una lista con paymentMethods y los categoriza segun su tipo de gasto(Expensetype)
//Devolviendo un string con cada ExpenseType y el total de gastos
//Es un Singleton pues no tiene sentido que exista más de un objeto.
//Cumple con SRP pues su única razon de cambio es cuando se realiza un nuevo gasto en algún PaymentMethod
//Cuando esto ocurre, el UserInterface llama a este Singleton para que
//Actualice la string con los gastos agregados por tipo.
namespace Library
{
    public class ExpenseAnalysis
    {
        public string Analysis;

        public ExpenseAnalysis()
        {
            this.Analysis = null;
        }
        public void CalculateTotalByType(List<PaymentMethod> payments, List<ExpenseType> expenseTypes)
        {
            string lista = "";
            if (expenseTypes.Count >= 1)
            {
                foreach (ExpenseType expenseType in expenseTypes)
                {
                    double total = 0;
                    foreach (PaymentMethod item in payments)
                    {
                        if (typeof(Wallet).IsInstanceOfType(item))
                        {
                            foreach (SubWallet subwallet in ((Wallet)item).SubWalletList)
                            {
                                foreach (Transactions transaction in subwallet.Statement.Transactions)
                                {
                                    if (transaction.IsPositive == false)
                                    {
                                        if (((Expense)transaction).ExpenseType == expenseType)
                                        {
                                            total = total + transaction.Ammount*transaction.Currency.ExchangeRate;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (Transactions transaction in item.CurrentStatement.Transactions)
                            {
                                if (transaction.IsPositive == false)
                                {
                                    if (((Expense)transaction).ExpenseType == expenseType)
                                    {
                                        total = total + transaction.Ammount*transaction.Currency.ExchangeRate;
                                    }
                                }
                            }
                        }
                    }
                    expenseType.ChangeTotal(total);
                    lista = lista + $"Gastos en {expenseType} ${expenseType.Total} pesos.\n";
                }
            }
            this.Analysis = lista;
        }
    }
}