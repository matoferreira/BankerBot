using System;
using System.Collections.Generic;

namespace Library
{
    //Se deja intencionalmente esta clase vacía, dado a que su implementación refiere al flujo completo de trabajo del bot
    //por estar en una primera instancia del desarrollo del mismo, no se cuenta con estos detalles aún.
    public class UserInterface
    {
        public IStringImput StringImput = Singleton<ConsoleReader>.Instance;
        public IIntImput IntImput = Singleton<IntConsoleReader>.Instance;
        public IExitFormat Output = Singleton<ConsolePrinter>.Instance;
        public ExpenseAnalysis ExpenseAnalysis = Singleton<ExpenseAnalysis>.Instance;
        public SavingsAnalysis SavingsAnalysis = Singleton<SavingsAnalysis>.Instance;
        private UserProfile profile;
        public UserInterface()
        {
            this.profile = new UserProfile();
            Output.PrintLine(
                "Opciones Posibles: \n" +
                "1. AgregarPaymentMethod\n" +
                "2. Cambia Alerta \n" +
                "3. Mostrar Status \n" 
            );
            this.MainMenu();

        }
        public void MainMenu()
        {
            int x = IntImput.GetImput("Ingrese el número de la opción deseada:");
            switch (x)
            {
                case 1:
                {
                    this.NewPaymentMethod();
                    break;
                }
                case 2:
                    {
                       this.ChangeAlertLevel();
                       break; 
                    }
                    
                case 3:
                    {
                        this.GetStatus();
                        break;
                    }
                default:
                    Output.PrintLine("Unknown value");
                    break;
            }
        }
        public void NewPaymentMethod()
        {
            int x = IntImput.GetImput("1. Agregar nueva cuenta bancaria \n 2. Agregar nueva tarjeta de Crédito \n 3. Agregar nueva billetera");
            switch (x)
            {
                case 1:
                {
                    string nombre = StringImput.GetImput("Ingrese el nombre del banco");
                    int intmoneda= IntImput.GetImput("Ingrese una Moneda: \n1. USD \n2. EUR \n3.Pesos");
                    string moneda = "";
                    switch (intmoneda)
                    {
                        case 1:
                        {
                            moneda = "USD";
                            break;
                        }
                        case 2:
                        {
                            moneda = "EUR";
                            break;
                        }
                        case 3:
                        {
                            moneda = "Pesos";
                            break;
                        }
                        default:
                        {
                            Output.PrintLine("Unknown value");
                            break;
                        }
                    }
                    Currency currency = new Currency(moneda);
                    BankAccount banco = new BankAccount(nombre, currency);
                    double saldo = IntImput.GetImput("Ingrese el saldo de la cuenta");
                    banco.CurrentStatement.ChangeBalance(saldo);
                    profile.AddPaymentMethod(banco);
                    break;
                }
                    
                case 2:
                {
                    string nombre2 = StringImput.GetImput("Ingrese el nombre de la tarjeta");
                    int intmoneda2 = IntImput.GetImput("Ingrese una Moneda: \n1. USD \n2. EUR \n3.Pesos");
                    string moneda2 = "";
                    switch (intmoneda2)
                    {
                        case 1:
                        {
                            moneda2 = "USD";
                            break;
                        }
                        case 2:
                        {
                            moneda2 = "EUR";
                            break;
                        }
                        case 3:
                        {
                            moneda2 = "Pesos";
                            break;
                        }
                        default:
                        {
                            Output.PrintLine("Unknown value");
                            break;
                        }
                    }
                    Currency currency2 = new Currency(moneda2);
                    double limite = IntImput.GetImput("Ingrese el limite de gasto de la tarjeta");
                    CreditCard tarjeta = new CreditCard(nombre2, currency2, limite);
                    profile.AddPaymentMethod(tarjeta);
                    break;
                }
                    
                case 3:
                {
                    int intmoneda3 = IntImput.GetImput("Ingrese la Moneda de la billetera: \n1. USD \n2. EUR \n3.Pesos");
                    string moneda3 = "";
                    switch (intmoneda3)
                    {
                        case 1:
                        {
                            moneda3 = "USD";
                            break;
                        }
                        case 2:
                        {
                            moneda3 = "EUR";
                            break;
                        }
                        case 3:
                        {
                            moneda3 = "Pesos";
                            break;
                        }
                        default:
                        {
                            Output.PrintLine("Unknown value");
                            break;
                        }
                    }
                    Currency currency3 = new Currency(moneda3);
                    break;
                }
                    
                default:
                    Output.PrintLine("Unknown value");
                    break;
            }
            Output.PrintLine("Medio de pago agregado");
        }
        public void ChangeAlertLevel()
        {
            Alert alerta;
            int x = IntImput.GetImput("Ingrese la Alerta a cambiar: \n1. Ahorro Mensual \n2. Fondos Bajos \n3. Gastos Altos");
            switch (x)
            {
                case 3:
                {
                    alerta = profile.Alerts.Find(x => x is HighSpendingAlert);
                    double newLevel = IntImput.GetImput("Ingrese el Limite de gastos mensuales a controlar");
                    alerta.ChangeLevel(newLevel);
                    break;
                }
                case 2:
                {
                    alerta = profile.Alerts.Find(x => x is LowFundsAlert);
                    double newLevel = IntImput.GetImput("Ingrese el monto minimo de fondos deseado");
                    alerta.ChangeLevel(newLevel);
                    break;
                }
                case 1:
                {
                    alerta = profile.Alerts.Find(x => x is SavingsTargetAlert);
                    double newLevel = IntImput.GetImput("Ingrese el monto a ahorrar por mes");
                    alerta.ChangeLevel(newLevel);
                    break;
                }
                default:
                {
                    Output.PrintLine("Unknown value");
                    break;
                }
            }
            Output.PrintLine("Alerta Cambiada");
        }
        public string GetStatus()
        {
            string status = "";
            foreach (PaymentMethod method in profile.PaymentMethods)
            {
                if (typeof(BankAccount).IsInstanceOfType(method))
                {
                    status = status + $"Saldo en {((BankAccount)method).BankName} en {method.Currency} es {method.GetBalance()}\n#";
                }
                if (typeof(CreditCard).IsInstanceOfType(method))
                {
                    status = status + $"Saldo en {((CreditCard)method).CardName} en {method.Currency} es {method.GetBalance()}\n#";
                }
                if (typeof(Wallet).IsInstanceOfType(method))
                {
                    status = status + $"Saldo en la billetera es: \n#";
                    foreach (SubWallet item in ((Wallet)method).SubWalletList)
                    {
                        status = status + $"Saldo en {item.Currency} es: {((Wallet)method).GetBalanceBySubWallet(item)}\n#";
                    }
                }
                this.ShowExpensesAnalysis();
                Output.PrintLine("\n");
                this.ShowSavingsAnalysis();
                Output.PrintLine("\n");
            }
            foreach (Alert item in profile.Alerts)
            {
                if (item.IsOn == true)
                {
                    status = status + $"{item.Message}\n#";
                }
            }
            return status;
        }
        public void ShowSavingsAnalysis()
        {
            Output.PrintLine($"{SavingsAnalysis.AnalyseSavings(profile.PaymentMethods)}#");
        }
        public void ShowExpensesAnalysis()
        {
            Output.PrintLine($"{ExpenseAnalysis.CalculateTotalByType(profile.PaymentMethods)}#");
        }
    }
}
