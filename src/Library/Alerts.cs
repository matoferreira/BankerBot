using System;
using System.Collections.Generic;

namespace Library
{
    //
    public class Alerts
    {
        public double SavingsTarget { get; private set; }
        public double LowFundsLevel { get; private set; }
        public double HighSpendingLevel { get; private set; }
        public Alerts()
        {

        }
        public void ChangeHighSpendingLevel(double newvalue)
        {

        }
        public void ChangeLowFundsLevel(double newvalue)
        {
            
        }
        public void ChangesavingsTarget(double newvalue)
        {
            
        }
        public void SendAlert(string alert)
        {
            
        }
        public double CheckSavingsProgress()
        {
            return 0;
        }
        public void TrackFunds(List<IPaymentMethod> list)
        {
            
        }
        public void TrackSavings(List<IPaymentMethod> list)
        {
            
        }
        public void TrackSpending(List<IPaymentMethod> list)
        {
            
        }
    }
}