using System;

namespace Library
{
    public class UpdateLowFundsAlertHandler : AbstractHandler
    {
        public IIntInput IntImput = Singleton<IntConsoleReader>.Instance;
        public override void Handle(Request request)
        {
            if (request.Content == "/alertabajosfondos")
            {
                Alert alerta;
                alerta = request.Profile.Alerts.Find(x => x is LowFundsAlert);

                double newLevel = IntImput.GetInput("Ingrese el monto minimo de fondos deseado:");
                
                alerta.ChangeLevel(newLevel);
                Output.PrintLine("Alerta actualizada con éxito.");

                base.Handle(request);
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}