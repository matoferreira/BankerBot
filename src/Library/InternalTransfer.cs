using System;
namespace Library
//Esta clase debe conocer el medio de pago destino de la transferencia interna, el concepto monto y moneda.
{
    public class InternalTransfer: Transactions
    {
        
        private double ammount;

        private DateTime dateTime;

        public InternalTransfer (String concept, double ammount, Currency currency, PaymentMethod destination ){

        }


    }
}