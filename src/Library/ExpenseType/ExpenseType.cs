using System;
using System.Collections.Generic;

//Esta clase será instanciada por cada rubro de gasto que exista
//Su unica responsabilidad es conocer su nombre para que luego se pueda usar para categorizar los gastos
namespace Library
{
    public class ExpenseType
    {
        public string Name { get; private set; }

        public double Total { get; private set; }


        public ExpenseType(string name)
        {
            this.Name = name;
        }



    }

}