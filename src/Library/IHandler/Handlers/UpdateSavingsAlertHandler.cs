using System;

namespace Library
{
    public class UpdateSavingsAlertHandler : AbstractHandler
    {
        public IIntInput IntImput = Singleton<IntConsoleReader>.Instance;
        public override object Handle(Request request)
        {
            if (request.Content == "/alertadeahorros")
            {
                Alert alerta;
                alerta = request.Profile.Alerts.Find(x => x is SavingsTargetAlert);

                double newLevel = IntImput.GetInput("Ingrese el monto del objetivo de ahorro:");
                
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