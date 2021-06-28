using System;

//La función de esta API es interactuar con un webservice de cotizaciones
//Depende de una Interfaz IExchange, para independizar al bot del servicio web, y poder a futuro cambiarlo o agregar
//otro sin la necesidad de cambiar el codigo del core del bot.
//Esto busca que la interacción entre clases sea entre clases de alto nivel (Interfases) para cumplir con DIP
namespace Library
{
    public class CurrencyExchangeAPI : IExchange
    {
        public double UpdatedRate { get; protected set; }

        public double GetUpdatedRate()
        {
            return 2;
        }
    }
}
