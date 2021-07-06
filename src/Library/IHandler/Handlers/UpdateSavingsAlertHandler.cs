using System;

namespace Library
{
    public class UpdateSavingsAlertHandler: AbstractHandler
    {
        public IIntInput IntImput = Singleton<IntConsoleReader>.Instance;
        public override void Handle(Request request)
        {
            if (request.Content == "/AlertaAhorros")
            {
                Alert alerta;
                alerta = profile.Alerts.Find(x => x is LowFundsAlert);

                double newLevel = IntImput.GetInput("Ingrese el monto a ahorrar por mes");
                
                alerta.ChangeLevel(newLevel);
                base.Handle(request);
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}