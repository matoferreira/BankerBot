using System;

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
