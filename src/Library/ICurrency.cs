using System;

namespace Library
{
    public interface ICurrency
    {
        string Name{ get; }
        string Country{ get; }
        double ExchangeRate{ get; }

        void UpdateExchangeRate();
        //double GetExchangeRate()
        //{ para que

        //}
        double Convert(double ammount);
    }
}
