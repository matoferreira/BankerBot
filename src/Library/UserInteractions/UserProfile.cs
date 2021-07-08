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
        public ExpenseAnalysis ExpenseAnalysis;
        public SavingsAnalysis SavingsAnalysis;
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
            ExpenseAnalysis.CalculateTotalByType(PaymentMethods);
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

    }
}
