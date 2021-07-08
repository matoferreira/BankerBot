using System;

namespace Library
{
    public class StatusHandler : AbstractHandler
    {
        public override object Handle(Request request)
        {
            if (request.Content == "/estado")
            {
                string status = "";
                request.Profile.Update();
                foreach (PaymentMethod method in request.Profile.PaymentMethods)
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
                foreach (Alert item in request.Profile.Alerts)
                {
                    if (item.IsOn == true)
                    {
                        status = status + $"{item.Message}#";
                    }
                }
                
                return status;
            }
            else
            {
                return base.Next.Handle(request);
            }
        }
    }
}