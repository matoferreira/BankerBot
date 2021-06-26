//Esta es una subclase de Statement, utilizada por la cuenta bancaria para almacenar sus movimientos de dinero.
//Es una especialización de Statement, que al ser concreta puede instanciarse.
//no importa la fecha asociada, un unico WalletStatement se usará para tener los movimientos de cada subwallet, pues 
//para la billetera solo importa saber la cantidad de dinero que se tiene en el momento.

using System;
using System.Collections.Generic;

namespace Library
{
    public class WalletStatement : Statement
    {
        public WalletStatement(Currency currency)
        {
            this.Currency = currency;
            this.Date = new DateTime(2000, 01, 01);
            this.Balance = 0;
        }
    }
}