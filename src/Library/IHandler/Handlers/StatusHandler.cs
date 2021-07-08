using System;

namespace Library
{
    public class StatusHandler : AbstractHandler
    {
        public override void Handle(Request request)
        {
            if (request.Content == "/estado")
            {
                string status = "";
                profile.Update();
                foreach (PaymentMethod method in profile.PaymentMethods)
                {
                    if (typeof(BankAccount).IsInstanceOfType(method))
                    {
                        status = status + $"Saldo en cuenta bancaria {((BankAccount)method).Name} en {((BankAccount)method).Currency.Name} es {((BankAccount)method).GetBalance()}#";
                    }
                    if (typeof(CreditCard).IsInstanceOfType(method))
                    {
                        status = status + $"Saldo en {((CreditCard)method).Name} en {method.Currency.Name} es {method.GetBalance()}#";
                    }
                    if (typeof(Wallet).IsInstanceOfType(method))
                    {
                        status = status + $"Saldo en la billetera es: #";
                        foreach (SubWallet item in ((Wallet)method).SubWalletList)
                        {
                            status = status + $"{((Wallet)method).GetBalanceBySubWallet(item)} Pesos#";
                        }
                    }
                }
                foreach (Alert item in profile.Alerts)
                {
                    if (item.IsOn == true)
                    {
                        status = status + $"{item.Message}#";
                    }
                }
                
                Output.PrintLine(status);
                Output.PrintLine("------------------------#");
               
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}