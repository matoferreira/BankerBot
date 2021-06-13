using System;

namespace Library
{
    public interface ICurrency
    {
        String Name {get; set;}
        double ExchangeRate {get; set;}
        void UpdateExchangeRate();
        double Convert(double ammount);
    }
}