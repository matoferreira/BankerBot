using System;

namespace Library
{
    public interface ICurrency
    {
        string Name{ get; }
        double ExchangeRate { get; }

        void UpdateExchangeRate();
        double Convert(double ammount);
    }
}
