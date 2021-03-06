using System;

namespace Library
{
    public class UpdateSavingsAlertHandler : AbstractHandler
    {
        public IIntInput IntImput = Singleton<IntConsoleReader>.Instance;
        public override void Handle(Request request)
        {
            if (request.Content == "/alertadeahorros")
            {
                Alert alerta;
                alerta = request.Profile.Alerts.Find(x => x is SavingsTargetAlert);

                double newLevel = IntImput.GetInput("Ingrese el monto del objetivo de ahorro:");
                
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