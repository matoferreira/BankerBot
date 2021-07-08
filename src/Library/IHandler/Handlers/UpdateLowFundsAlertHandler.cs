using System;

namespace Library
{
    public class UpdateLowFundsAlertHandler : AbstractHandler
    {
        public IIntInput IntImput = Singleton<IntConsoleReader>.Instance;
        public override object Handle(Request request)
        {
            if (request.Content == "/alertabajosfondos")
            {
                Alert alerta;
                alerta = request.Profile.Alerts.Find(x => x is LowFundsAlert);

                double newLevel = IntImput.GetInput("Ingrese el monto minimo de fondos deseado:");
                
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