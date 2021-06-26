using System;
using System.Collections.Generic;

namespace Library
{
//Se deja intencionalmente esta clase vacía, dado a que su implementación refiere al flujo completo de trabajo del bot
//por estar en una primera instancia del desarrollo del mismo, no se cuenta con estos detalles aún.
    public class UserInterface
    {
        public Singleton<TelegramAPI> Telegram;
        public Singleton<ExcelAPI> Excel;
        private UserProfile profile;
        public UserInterface()
        {
            this.profile = new UserProfile();
        }
        public void NewPaymentMethod(PaymentMethod newMethod)
        {
            profile.AddPaymentMethod(newMethod);
        }
        public void ChangeAlertLevel(Alert alert, double newLevel)
        {
            if (profile.Alerts.Contains(alert))
            {
                profile.Alerts[profile.Alerts.IndexOf(alert)].ChangeLevel(newLevel);
            }
        }
        public string GetStatus()
        {
            string status = "";
            foreach (PaymentMethod method in profile.PaymentMethods)
            {
                if (typeof(BankAccount).IsInstanceOfType(method))
                {
                    status = status + $"Saldo en {((BankAccount)method).BankName} en {method.Currency} es {method.GetBalance()}\n";
                }
                if (typeof(CreditCard).IsInstanceOfType(method))
                {
                    status = status + $"Saldo en {((CreditCard)method).CardName} en {method.Currency} es {method.GetBalance()}\n";
                }
                if (typeof(Wallet).IsInstanceOfType(method))
                {
                    status = status + $"Saldo en la billetera es: \n";
                    foreach (SubWallet item in ((Wallet)method).SubWalletList)
                    {
                        status = status + $"Saldo en {item.Currency} es: {((Wallet)method).GetBalanceBySubWallet(item)}\n";
                    }
                }
            }
            foreach (Alert item in profile.Alerts)
                {
                    if (item.IsOn == true)
                    {
                        status = status + $"{item.Message}\n";
                    }
                }
            return status;
        }
        public void ShowSavingsAnalysis()
        {
            //Falta Hacer
        }
        public void ShowExpensesAnalysis()
        {
            //Falta Hacer
        }
    }
}
