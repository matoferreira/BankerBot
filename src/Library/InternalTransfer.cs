using System;
namespace Library
//Esta clase debe conocer el medio de pago destino de la transferencia interna, el concepto monto y moneda.
////Es un subtipo de Transactions, esto permite que por el principio LSP, donde se espera un tipo Transactions, acepte un subtipo InternalTransfer
{
    public class InternalTransfer: Transactions
    {
        
        public DateTime DateTime{ get; private set; }

        protected PaymentMethod Destination;

        public InternalTransfer (String concept, double ammount, Currency currency, PaymentMethod destination )
        {
            this.Concept = concept;
            this.Ammount = ammount;
            this.Destination = destination;
            destination.CurrentStatement.AddTransaction(new Income(concept, ammount, currency));
        }

       

        


    }
}