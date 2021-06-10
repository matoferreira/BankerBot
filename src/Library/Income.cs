using System;

namespace Library
{
//Es un subtipo de Transactions, esto permite que por el principio LSP, donde se espera un tipo Transactions, acepte un subtipo Income
//Representa un ingreso de dinero o un pago del saldo de la tarjeta de crédito
    public class Income: Transactions
    {
        public double ammount { get; private set; }
        public string Concept { get; private set; } 

        public Income (String concept, double ammount, Currency currency)
        {

        }
    }
}