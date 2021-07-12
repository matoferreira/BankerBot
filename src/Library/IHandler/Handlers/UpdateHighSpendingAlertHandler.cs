using System;

namespace Library
{
    public class UpdateHighSpendingAlertHandler : AbstractHandler
    {
        public IIntInput IntImput = Singleton<IntConsoleReader>.Instance;
        public override void Handle(Request request)
        {
            if (request.Content == "/alertagastosmensuales")
            {
                Alert alerta;
                alerta = request.Profile.Alerts.Find(x => x is HighSpendingAlert);

                double newLevel = IntImput.GetInput("Ingrese su límite de gastos mensuales:");
                
                alerta.ChangeLevel(newLevel);
                Output.PrintLine("Alerta actualizada con éxito.");
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}