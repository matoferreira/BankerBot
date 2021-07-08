using System;

namespace Library
{
    public class UpdateHighSpendingAlertHandler : AbstractHandler
    {
        public IIntInput IntImput = Singleton<IntConsoleReader>.Instance;
        public override object Handle(Request request)
        {
            if (request.Content == "/alertagastosmensuales")
            {
                Alert alerta;
                alerta = request.Profile.Alerts.Find(x => x is HighSpendingAlert);

                double newLevel = IntImput.GetInput("Ingrese su límite de gastos mensuales:");
                
                alerta.ChangeLevel(newLevel);
                return "Alerta actualizada con éxito.";
            }
            else
            {
                return base.Next.Handle(request);
            }
        }
    }
}