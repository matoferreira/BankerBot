using System;
using System.Collections.Generic;

namespace Library
{
//Se deja intencionalmente esta clase vacía, dado a que su implementación refiere al flujo completo de trabajo del bot
//por estar en una primera instancia del desarrollo del mismo, no se cuenta con estos detalles aún.
    public class UserInteface
    {
        private UserProfile profile;
        public UserInteface()
        {
            this.profile = new UserProfile();
        }
        public void NewPaymentMethod(PaymentMethod newMethod)
        {
            profile.AddPaymentMethod(newMethod);
        }
        public void ChangeAlertLevel(Alert alert, double newLevel)
        {
            if (profile.Alerts.Contains(alert))
            {
                profile.Alerts[profile.Alerts.IndexOf(alert)].ChangeLevel(newLevel);
            }
            
        }
    }
}
