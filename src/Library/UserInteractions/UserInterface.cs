using System;
using System.Collections.Generic;

namespace Library
{
    //Esta clase actua como Mediador entre las diferentes clases del bot, buscando que éstas no interactúen entre sí.
    //De esta manera se reduce la dependencia entre ellas (Low Coupling) y permite que las demás clases sean cerradas
    //a la modificación.
    //Utilizamos Interfaces para manejar la entrada y salida de datos del bot, en el momento, solamente se interactúa
    //con la consola pero estas interfaces permitirán a futuro poder agregar más plataformas (Telegram, Whatsapp, Excel)
    //Sin tener que modificar el Core bot. De esta manera estamos abiertos a la extensión en el futuro (OSP)
    //Una interface de entrada acepta solamente int, y la utilizamos para recibir los comandos del usuario,
    //Mientras que la otra recibe strings para aceptar texto.
    //Utilizamos Singleton para implementar estos Mecanismos de Imput y Output de datos porque solo es necesario que
    //exita una instancia de ellos.
    public class UserInterface
    {
        public IStringInput StringImput = Singleton<ConsoleReader>.Instance;
        public IIntInput IntImput = Singleton<IntConsoleReader>.Instance;
        public IExitFormat Output = Singleton<ConsolePrinter>.Instance;
        protected UserProfile profile;
        public HandlersList Handlers = new HandlersList();
        public UserInterface()
        {
            this.profile = new UserProfile();
            this.MainMenu();
        }
        public void MainMenu()
        {
            Output.PrintLine(
                "Opciones Posibles: \n" +
                "1. Agregar Medio de Pago\n" +
                "2. Cambia Alerta \n" +
                "3. Mostrar Status \n" +
                "4. Agregar Movimiento \n" +
                "5. Ver Analisis de Ahorro \n" +
                "6. Ver Analisis de Gastos Mensuales \n" +
                "7. Imprimir Analisis de Ahorro en HTML\n" +
                "8. Imprimir Analisis de Gastos Mensuales en HTML \n" +
                "9. Salir \n"
            );
            int x = IntImput.GetInput("Ingrese el número de la opción deseada:");
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
                    case 7:
                    {
                        this.ShowSavingsAnalysisinHTML();
                        break;
                    }
                    case 8:
                    {
                        this.ShowExpensesAnalysisInHTML();
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

        private void ShowExpensesAnalysisInHTML()
        {
            Handlers.newBankAccountHandler.Handle(new Request("/mostrargastosHTML", profile));
            this.MainMenu();
        }

        private void ShowSavingsAnalysisinHTML()
        {
            Handlers.newBankAccountHandler.Handle(new Request("/mostrarahorrosHTML", profile));
            this.MainMenu();
        }

        public void NewPaymentMethod()
        {
            int x = IntImput.GetInput("1. Agregar nueva cuenta bancaria \n2. Agregar nueva tarjeta de Crédito \n3. Agregar nueva billetera");
            switch (x)
            {
                case 1:
                    {
                        Handlers.newBankAccountHandler.Handle(new Request("/agregarcuentabancaria", profile));
                        break;
                    }

                case 2:
                    {
                        Handlers.newBankAccountHandler.Handle(new Request("/agregartarjeta", profile));
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
            int x = IntImput.GetInput("Ingrese la Alerta a cambiar: \n1. Ahorro Mensual \n2. Fondos Bajos \n3. Gastos Altos");
            switch (x)
            {
                case 3:
                    {
                        Handlers.newBankAccountHandler.Handle(new Request("/alertagastosmensuales", profile));
                        break;
                    }
                case 2:
                    {
                        Handlers.newBankAccountHandler.Handle(new Request("/alertabajosfondos", profile));
                        break;
                    }
                case 1:
                    {
                        Handlers.newBankAccountHandler.Handle(new Request("/alertadeahorros", profile));
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
            Handlers.newBankAccountHandler.Handle(new Request("/estado", profile));
            this.MainMenu();
        }
        public void ShowSavingsAnalysis()
        {
            Output.PrintLine($"{profile.SavingsAnalysis.AnalyseSavings(profile.PaymentMethods)}#");
            this.MainMenu();
        }
        public void ShowExpensesAnalysis()
        {
            Output.PrintLine($"{profile.ExpenseAnalysis.CalculateTotalByType(profile.PaymentMethods, UserProfile.ExpenseTypes)}#");
            this.MainMenu();
        }
        public void AddMovement()
        {
            int y = IntImput.GetInput("Elegir movimiento a agregar: \n1. Ingreso \n2. Gasto \n3. Transferencia Interna");
            switch (y)
            {
                case 1:
                    {
                        Handlers.newBankAccountHandler.Handle(new Request("/agregaringreso", profile));
                        break;
                    }
                case 2:
                    {
                        Handlers.newBankAccountHandler.Handle(new Request("/agregargasto", profile));
                        break;
                    }
                case 3:
                    {
                        Handlers.newBankAccountHandler.Handle(new Request("/agregartransferenciainterna", profile));
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
