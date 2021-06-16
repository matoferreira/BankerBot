using System;
using System.Collections.Generic;

//Esta clase será instanciada por cada rubro de gasto que exista
//Es la experta (patrón Expert) en calcular el total por rubro ya que su única responsabilidad
//es acumular los gastos por rubro (Principio SRP)
namespace Library
{
    public class ExpenseType
    {
        public string Name { get; private set; }
        public List<PaymentMethod> PaymentMethods { get; private set; }

        public double Total {get; private set;}


        public ExpenseType (string name )
        {
            this.Name = name;
        }
      
        public void CalculateTotal(List<Expense> expenses)
        {
            Total = 0;
            foreach (PaymentMethod paymentMethod in PaymentMethods)
            {
                foreach (Expense expense in BankAccountStatement.)
            }
           
        }

         public void AccumulateExpensesByType(List<Expense> expenses)
         {  
           foreach (Expense expense in expenses)
           {
               Expenses.Add(expense);
           }
           
         }

    }
}