using System;
using System.Collections.Generic;

namespace Library
{
    public class HighSpendingAlert : Alert
    {
        public HighSpendingAlert(string name, double level, string message) : base(name, level, message)
        {

        }
    }
}