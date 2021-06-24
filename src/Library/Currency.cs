using System;

//Esta clase interactúa con el ExchangeAPI, dado a esto es la experta (patrón Expert) en actualizar el valor de su moneda
//Porque conoce como hacerlo y conoce que moneda es.
//Cumple con SRP, ya que solo cambia al actualizar su exchange rate con respecto al dolar
//Y su responsabilidad es convertir la moneda en un valor equivalente en dólares y de dolares a la moneda específica 
namespace Library
{
    public class Currency : ICurrency
    {
        public string Name { get ; set ; }
        public double ExchangeRate { get ; set ; }
        public IExchange Exchanger = new CurrencyExchangeAPI();

        public Currency(string name)
        {
            this.Name = name;
            this.ExchangeRate = 1;
        }
        public double Convert(double ammount)
        {
            this.UpdateExchangeRate();
            return this.ExchangeRate*ammount;
        }

        public void UpdateExchangeRate()
        {
            //No se implementa este método por interactuar con un servicio externo pero si se
            //deja la lógica de como sería.
            double UpdatedRate = 0;
            UpdatedRate = Exchanger.GetUpdatedRate();
        }
    }
}
