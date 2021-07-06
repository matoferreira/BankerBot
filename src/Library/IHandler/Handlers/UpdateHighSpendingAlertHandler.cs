using System;

namespace Library
{
    public class UpdateHighSpendingAlertHandler: AbstractHandler
    {
        public IIntInput IntImput = Singleton<IntConsoleReader>.Instance;
        public override void Handle(Request request)
        {
            if (request.Content == "/AlertaGastosMensuales")
            {
                Alert alerta;
                alerta = profile.Alerts.Find(x => x is HighSpendingAlert);

                double newLevel = IntImput.GetInput("Ingrese el Limite de gastos mensuales a controlar");
                
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