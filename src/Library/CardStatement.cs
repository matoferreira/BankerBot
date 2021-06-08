using System;

namespace Library
{
    public class CardStatement : Statement
    {
        private double limit;
        CardStatement(Currency moneda, DateTime fecha, double limite)
        {
            this.Moneda = moneda;
            this.Fecha = fecha;
            this.limit = limite;
        }
        public override void AddTransaction()
        {

        }
        public override void RemoveTransaction()
        {

        }
        public override double GetBalance()
        {

        }
        public override double AccumulateExpenses()
        {
            
        }
    }
}