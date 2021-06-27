using System;


namespace Library
{

    public interface IExchange
    {
        double UpdatedRate { get; set; }
        double GetUpdatedRate()
        {
            return 2;
        }
    }
}
