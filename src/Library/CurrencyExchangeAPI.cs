using System;

//La función de esta API es interactuar con un webservice de cotizaciones
namespace Library
{
    //Desarrollar una abstracción
    public class CurrencyExchangeAPI : IExchange
    {
        public double UpdatedRate { get ; set; }

        public double GetUpdatedRate()
        {
            return 2;
        }
    }
}
