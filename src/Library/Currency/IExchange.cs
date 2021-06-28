using System;


namespace Library
{

    public interface IExchange
    {
        double UpdatedRate { get; }
        double GetUpdatedRate()
        {
            return 2;
        }
    }
}
