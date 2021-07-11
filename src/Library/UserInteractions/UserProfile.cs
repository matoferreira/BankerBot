using System;
using System.Collections.Generic;
//Esta clase almacena todas la información del usuario. Agrega los paymentMethod que es usuario configuró y las
//alertas que utiliza, también permite modificarlas. Es el Creator de los PaymentMethod, y tambien los observa
//según patrón observer, pra notificar de sus cambios a las alertas, quienes necesitan conocerlos para
//operar.
namespace Library
{
    public class UserProfile : IObserver
    {
        public List<Alert> Alerts { get; private set; }
        public List<PaymentMethod> PaymentMethods { get; private set; }
        public static List<ExpenseType> ExpenseTypes { get; private set; }
        public ExpenseAnalysis ExpenseAnalysis = new ExpenseAnalysis();
        public SavingsAnalysis SavingsAnalysis = new SavingsAnalysis();
        public UserProfile()
        {
            this.PaymentMethods = new List<PaymentMethod>();
            ExpenseTypes = new List<ExpenseType>();
            this.AddExpenseType("Sin Asignar");
            this.AddExpenseType("Transferencia Interna");
            this.AddPaymentMethod(new Wallet(new SubWallet("Pesos", new Currency("Pesos"))));
            this.Alerts = new List<Alert>();
            Alerts.Add(new HighSpendingAlert());
            Alerts.Add(new SavingsTargetAlert());
            Alerts.Add(new LowFundsAlert());
        }
        public void AddAlert(Alert newAlert)
        {
            if (!Alerts.Contains(newAlert))
            {
                Alerts.Add(newAlert);
            }
        }
        public void RemoveAlert(Alert Alert)
        {
            if (Alerts.Contains(Alert))
            {
                Alerts.Remove(Alert);
            }
        }
        public void AddPaymentMethod(PaymentMethod newMethod)
        {
            if (!PaymentMethods.Contains(newMethod))
            {
                PaymentMethods.Add(newMethod);
                newMethod.Subscribe(this);
            }
        }
        public void RemovePaymentMethod(PaymentMethod method)
        {
            if (PaymentMethods.Contains(method))
            {
                PaymentMethods.Remove(method);
            }
        }
        public void AddExpenseType(string nombre)
        {
            if (!ExpenseTypes.Exists(x => ExpenseType.Name  == nombre))
            {
                ExpenseTypes.Add(new ExpenseType(nombre));
            }
        }
        public void RemoveExpenseType(ExpenseType type)
        {
            if (ExpenseTypes.Contains(type))
            {
                ExpenseTypes.Remove(type);
            }
        }

        public void Update()
        {
            foreach (Alert alert in Alerts)
            {
                alert.TrackLevel(PaymentMethods);
            }
            SavingsAnalysis.AnalyseSavings(PaymentMethods);
            ExpenseAnalysis.CalculateTotalByType(PaymentMethods, ExpenseTypes);
        }
        public bool AddMovement(PaymentMethod paymentMethod, string concept, double ammount, Currency currency, bool isPositive)
        {
            return paymentMethod.AddMovement(concept, ammount, currency, isPositive, ExpenseTypes[0]);
        }
        public void ChangeExpenseType(Expense expense, string newType)
        {
            AddExpenseType(newType);
            expense.ChangeExpenseType(ExpenseTypes.Find(x => ExpenseType.Name == newType));
        }
        public virtual bool MakeInternalTransfer(string concept, double ammount, Currency currency, PaymentMethod origin, PaymentMethod destination)
        {
            bool correct = origin.AddMovement(concept, ammount, currency, false, ExpenseTypes[1]);
            if (correct == true)
            {
                AddMovement(destination, concept, ammount, currency, true);
            }
            return correct;
        }


        //Chequear si es posible hacer un refactor de SavingsAnalysis para usarlo acá
        public double TotalBalance()
        {
            double totalBalance = 0;
            foreach (PaymentMethod method in PaymentMethods)
            {
                if (typeof(BankAccount).IsInstanceOfType(method))
                    {
                        totalBalance = totalBalance + method.GetBalance();
                    }
                    if (typeof(CreditCard).IsInstanceOfType(method))
                    {
                        totalBalance = totalBalance + method.GetBalance();
                    }
                    if (typeof(Wallet).IsInstanceOfType(method))
                    {
                        foreach (SubWallet item in ((Wallet)method).SubWalletList)
                        {
                            totalBalance = totalBalance + ((Wallet)method).GetBalanceBySubWallet(item);
                        }
                    }
                return totalBalance;
            }
            return totalBalance;
        }

        //Chequear si lo hacemos en una clase aparte
        public double TotalExpense()
        {
            double totalExpense = 0;
            if (ExpenseTypes.Count >= 1)
            {
                foreach (ExpenseType expenseType in ExpenseTypes)
                {
                    foreach (PaymentMethod item in PaymentMethods)
                    {
                        if (typeof(Wallet).IsInstanceOfType(item))
                        {
                            foreach (SubWallet subwallet in ((Wallet)item).SubWalletList)
                            {
                                foreach (Transactions transaction in subwallet.Statement.Transactions)
                                {
                                    if (transaction.IsPositive == false)
                                    {
                                        if (((Expense)transaction).ExpenseType == expenseType)
                                        {
                                            totalExpense = totalExpense + transaction.Ammount*transaction.Currency.ExchangeRate;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (Transactions transaction in item.CurrentStatement.Transactions)
                            {
                                if (transaction.IsPositive == false)
                                {
                                    if (((Expense)transaction).ExpenseType == expenseType)
                                    {
                                        totalExpense = totalExpense + transaction.Ammount*transaction.Currency.ExchangeRate;
                                    }
                                }
                            }
                        }
                    }
                }
                return totalExpense;    
            }
            else
            {
                return totalExpense;
            }
        }

    }
}
