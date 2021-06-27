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
            this.MainMenu();
        }
        public void MainMenu()
        {
            Output.PrintLine(
                "Opciones Posibles: \n" +
                "1. AgregarPaymentMethod\n" +
                "2. Cambia Alerta \n" +
                "3. Mostrar Status \n" +
                "4. Agregar Movimiento \n" +
                "5. Ver Analisis de Ahorro \n" +
                "6. Ver Analisis de Gastos Mensuales \n" +
                "9. Salir \n"
            );
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
                case 4:
                    {
                        this.AddMovement();
                        break;
                    }
                case 5:
                    {
                        this.ShowSavingsAnalysis();
                        break;
                    }
                case 6:
                    {
                        this.ShowExpensesAnalysis();
                        break;
                    }
                case 9:
                    {
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
                    double saldo = Convert.ToDouble(IntImput.GetImput("Ingrese el saldo de la cuenta"));
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
            this.MainMenu();
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
            this.MainMenu();
        }
        public void GetStatus()
        {
            string status = "";
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
            this.MainMenu();
        }
        public void ShowSavingsAnalysis()
        {
            Output.PrintLine($"{SavingsAnalysis.AnalyseSavings(profile.PaymentMethods)}#");
        }
        public void ShowExpensesAnalysis()
        {
            //Esta dando error
            //Output.PrintLine($"{ExpenseAnalysis.CalculateTotalByType(profile.PaymentMethods)}#");
        }
        public void AddMovement()
        {
            int y = IntImput.GetImput("Elegir movimiento a agregar: 1. Ingreso 2. Gasto 3. Transferencia Interna");
            switch (y)
            {
                case 1:
                {
                    Output.PrintLine("Elija la cuenta a la que agrega el movimiento:");
                    foreach (PaymentMethod item in profile.PaymentMethods)
                    {
                        Output.PrintLine($"{profile.PaymentMethods.IndexOf(item)}. {item.Name}");
                    }
                    int z = IntImput.GetImput("Cuenta:");
                    double monto = Convert.ToDouble(IntImput.GetImput($"Ingrese el monto del ingreso en {profile.PaymentMethods[z].Currency.Name}"));
                    string concepto = StringImput.GetImput("Escriba el concepto del Ingreso");
                    Income mov = new Income(concepto, monto, profile.PaymentMethods[z].CurrentStatement.Currency);
                    bool movimiento = profile.PaymentMethods[z].CurrentStatement.AddTransaction(mov);
                    break;
                }
                case 2:
                {
                    Output.PrintLine("Elija la cuenta a la que agrega el gasto:");
                    foreach (PaymentMethod item in profile.PaymentMethods)
                    {
                        Output.PrintLine($"{profile.PaymentMethods.IndexOf(item)}. {item.Name}");
                    }
                    int l = IntImput.GetImput("Cuenta:");
                    double monto = Convert.ToDouble(IntImput.GetImput($"Ingrese el monto del gasto en {profile.PaymentMethods[l].Currency.Name}"));
                    string concepto = StringImput.GetImput("Escriba el concepto del gasto");
                    ExpenseType tipo = new ExpenseType(StringImput.GetImput("Ingrese el tipo del gasto"));
                    profile.PaymentMethods[l].CurrentStatement.AddTransaction(new Expense(concepto, monto, profile.PaymentMethods[l].Currency, tipo));
                    break;
                }
                case 3:
                {
                    Output.PrintLine("Elija la cuenta de la que proviene la transferencia:");
                    foreach (PaymentMethod item in profile.PaymentMethods)
                    {
                        Output.PrintLine($"{profile.PaymentMethods.IndexOf(item)}. {item.Name}");
                    }
                    int z = IntImput.GetImput("Cuenta a debitar:");
                    double monto = Convert.ToDouble(IntImput.GetImput($"Ingrese el monto a transferir en {profile.PaymentMethods[z].Currency.Name}"));
                    string concepto = StringImput.GetImput("Escriba el concepto de la transferencia");
                    Output.PrintLine("Elija la cuenta a la que envía la transferencia:");
                    foreach (PaymentMethod item in profile.PaymentMethods)
                    {
                        Output.PrintLine($"{profile.PaymentMethods.IndexOf(item)}. {item.Name}");
                    }
                    int destino = IntImput.GetImput("Cuenta a acreditar:");
                    profile.PaymentMethods[z].CurrentStatement.AddTransaction(new InternalTransfer(concepto, monto, profile.PaymentMethods[z].Currency, profile.PaymentMethods[destino]));
                    break;
                }
                default:
                {
                    Output.PrintLine("Error en eleccion");
                    break;
                }
            }
            Output.PrintLine("Movimiento realizado");
            this.MainMenu();
        }
    }
}
