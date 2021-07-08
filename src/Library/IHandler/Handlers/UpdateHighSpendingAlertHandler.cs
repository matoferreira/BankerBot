using System;

namespace Library
{
    public class UpdateHighSpendingAlertHandler : AbstractHandler
    {
        public IIntInput IntImput = Singleton<IntConsoleReader>.Instance;
        public override void Handle(Request request)
        {
            if (request.Content == "/AlertaGastosMensuales")
            {
                Alert alerta;
                alerta = profile.Alerts.Find(x => x is HighSpendingAlert);

                double newLevel = IntImput.GetInput("Ingrese su límite de gastos mensuales:");
                
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