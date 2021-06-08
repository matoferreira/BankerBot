using System;

namespace Library
{
    public class WalletStatement : Statement
    {
        WalletStatement(Currency moneda, DateTime fecha)
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