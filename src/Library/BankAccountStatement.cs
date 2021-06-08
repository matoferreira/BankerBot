using System;

namespace Library
{
    public class BankAccountStatement : Statement
    {
        BankAccountStatement(Currency moneda, DateTime fecha)
        {
            this.Moneda = moneda;
            this.Fecha = fecha;
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