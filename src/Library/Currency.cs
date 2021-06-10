using System;

//Esta clase interactúa con el ExchangeAPI, dado a esto es la experta (patrón Expert) en actualizar el valor de su moneda
//Porque conoce como hacerlo y conoce que moneda es.
namespace Library
{
    public class Currency : ICurrency
    {
        public string Name { get; private set; }
        public double ExchangeRate { get; private set; }
        public Currency(string name)
        {
            this.Name = name;
            this.ExchangeRate = 1;
        }
        public double Convert(double ammount)
        {
            throw new NotImplementedException();
        }

        public void UpdateExchangeRate()
        {
            throw new NotImplementedException();
        }
    }
}
