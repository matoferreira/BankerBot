using System;
using System.Collections.Generic;

namespace Library
{
    //Esta clase actua como Mediador entre las diferentes clases del bot, buscando que éstas no interactúen entre sí.
    //De esta manera se reduce la dependencia entre ellas (Low Coupling) y permite que las demás clases sean cerradas
    //a la modificación.
    //Utilizamos Interfaces para manejar la entrada y salida de datos del bot, en el momento, solamente se interactúa
    //con la consola pero estas interfaces permitirán a futuro poder agregar más plataformas (Telegram, Whatsapp, Excel)
    //Sin tener que modificar el Core bot.
    //Una interface de entrada acepta solamente int, y la utilizamos para recibir los comandos del usuario,
    //Mientras que la otra recibe strings para aceptar texto.
    //Utilizamos Singleton para implementar estos Mecanismos de Imput y Output de datos porque solo es necesario que
    //exita una instancia de ellos.
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
            this.MainMenu();
        }
        public void ShowSavingsAnalysis()
        {
            Output.PrintLine($"{SavingsAnalysis.AnalyseSavings(profile.PaymentMethods)}#");
            this.MainMenu();
        }
        public void ShowExpensesAnalysis()
        {
            //Esta dando error
            //Output.PrintLine($"{ExpenseAnalysis.CalculateTotalByType(profile.PaymentMethods)}#");
            this.MainMenu();
        }
        public void AddMovement()
        {
            bool movimiento;
            int y = IntImput.GetImput("Elegir movimiento a agregar: \n1. Ingreso \n2. Gasto \n3. Transferencia Interna");
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
                    double monto = IntImput.GetImput($"Ingrese el monto del ingreso");
                    string concepto = StringImput.GetImput("Escriba el concepto del Ingreso");
                    int intmoneda3 = IntImput.GetImput("Ingrese la Moneda de la transacción: \n1. USD \n2. EUR \n3.Pesos");
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
                    if (typeof(Wallet).IsInstanceOfType(profile.PaymentMethods[z]))
                    {
                        movimiento = ((Wallet)profile.PaymentMethods[z]).SubWalletList.Find(x => x.Currency.Name == currency3.Name).Statement.AddTransaction(new Income(concepto, monto, currency3));
                    }
                    else
                    {
                        movimiento = profile.PaymentMethods[z].CurrentStatement.AddTransaction(new Income(concepto, monto, currency3));
                    }
                    
                    break;
                }
                case 2:
                {
                    Output.PrintLine("Elija la cuenta a la que agrega el gasto:");
                    foreach (PaymentMethod item in profile.PaymentMethods)
                    {
                        Output.PrintLine($"{profile.PaymentMethods.IndexOf(item)}. {item.Name}");
                    }
                    int z = IntImput.GetImput("Cuenta:");
                    double monto = Convert.ToDouble(IntImput.GetImput($"Ingrese el monto del gasto"));
                    string concepto = StringImput.GetImput("Escriba el concepto del gasto");
                    ExpenseType tipo = new ExpenseType(StringImput.GetImput("Ingrese el tipo del gasto"));
                    int intmoneda3 = IntImput.GetImput("Ingrese la Moneda de la transacción: \n1. USD \n2. EUR \n3.Pesos");
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
                    if (typeof(Wallet).IsInstanceOfType(profile.PaymentMethods[z]))
                    {
                        movimiento = ((Wallet)profile.PaymentMethods[z]).SubWalletList.Find(x => x.Currency.Name == currency3.Name).Statement.AddTransaction(new Expense(concepto, monto, currency3, tipo));
                    }
                    else
                    {
                        movimiento = profile.PaymentMethods[z].CurrentStatement.AddTransaction(new Expense(concepto, monto, currency3, tipo));
                    }
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
                    int intmoneda3 = IntImput.GetImput("Ingrese la Moneda de la transacción: \n1. USD \n2. EUR \n3.Pesos");
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
                    double monto = Convert.ToDouble(IntImput.GetImput($"Ingrese el monto a transferir"));
                    string concepto = StringImput.GetImput("Escriba el concepto de la transferencia");
                    Output.PrintLine("Elija la cuenta a la que envía la transferencia:");
                    foreach (PaymentMethod item in profile.PaymentMethods)
                    {
                        Output.PrintLine($"{profile.PaymentMethods.IndexOf(item)}. {item.Name}");
                    }
                    int destino = IntImput.GetImput("Cuenta a acreditar:");
                    if (typeof(Wallet).IsInstanceOfType(profile.PaymentMethods[z]))
                    {
                        movimiento = ((Wallet)profile.PaymentMethods[z]).SubWalletList.Find(x => x.Currency.Name == currency3.Name).Statement.AddTransaction(new InternalTransfer(concepto, monto, currency3, profile.PaymentMethods[destino]));
                    }
                    else
                    {
                        movimiento = profile.PaymentMethods[z].CurrentStatement.AddTransaction(new InternalTransfer(concepto, monto, currency3, profile.PaymentMethods[destino]));
                    }
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
