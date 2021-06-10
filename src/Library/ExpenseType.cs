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
        public List<Expense> expenses { get; private set; }


        public ExpenseType (string name )
        {

        }
      
        public double CalculateTotaByType(List<Expense> expenses)
        {
            return 0;
        }

         public void AccumulateExpensesByType(List<Expense> expenses)
         {  
           
         }

    }
}