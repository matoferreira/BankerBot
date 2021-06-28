using System;
//Se crea la clase abstracta transactions para que las clases que representan a los medios de pago puedan usarla para agregar 
//tanto ingresos como gasto o transferencias internas
namespace Library
{
    public abstract class Transactions
    {
        public Currency Currency { get; protected set; }
        public DateTime Date { get; protected set; }
        public double Ammount { get; protected set; }
        public string Concept { get; protected set; }

    }
}