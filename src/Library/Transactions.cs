using System;

namespace Library
{
    public abstract class Transactions
    {
        public Currency Currency { get ; private set; }
        public DateTime Date { get; private set; }

    }
}