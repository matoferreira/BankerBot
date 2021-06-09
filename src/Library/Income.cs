using System;

namespace Library
{
    public class Income: Transactions
    {
        public double ammount { get; private set; }
        public string Concept { get; private set; } 

        public Income (String concept, double ammount, Currency currency)
        {

        }
    }
}