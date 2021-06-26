using System;
using System.Collections.Generic;

namespace Library
{
//Se deja intencionalmente esta clase vacía, dado a que su implementación refiere al flujo completo de trabajo del bot
//por estar en una primera instancia del desarrollo del mismo, no se cuenta con estos detalles aún.
    public interface IMediator
    {
        void Notify(object sender, string ev);
    }
}