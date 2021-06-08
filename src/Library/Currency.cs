using System;

namespace Library
{
    public class Currency : ICurrency
    {
        public string Name { get; }
        public string Country { get; }
        public double ExchangeRate { get; }

        public Currency(string name, string country)
        {
            this.Name = name;
            this.Country = country;
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
