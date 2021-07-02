using System;
using System.Collections.Generic;

//Esta clase será instanciada por cada rubro de gasto que exista
//Su unica responsabilidad es conocer su nombre para que luego se pueda usar para categorizar los gastos (SRP)
namespace Library
{
    public class ExpenseType
    {
        public static string Name { get; private set; }

        public double Total { get; private set; }


        public ExpenseType(string name)
        {
            ExpenseType.Name = name;
        }



    }

}