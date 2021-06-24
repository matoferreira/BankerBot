using System;
using System.Collections.Generic;

namespace Library
{
    public class LowFundsAlert : Alert
    {
        public LowFundsAlert(string name, double level, string message) : base(name, level, message)
        {

        }
    }
}