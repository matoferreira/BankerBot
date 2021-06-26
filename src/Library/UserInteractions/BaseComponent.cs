using System;
using System.Collections.Generic;

namespace Library
{
//Se deja intencionalmente esta clase vacía, dado a que su implementación refiere al flujo completo de trabajo del bot
//por estar en una primera instancia del desarrollo del mismo, no se cuenta con estos detalles aún.
      public class BaseComponent
    {
        protected IMediator _mediator;

        public BaseComponent(IMediator mediator = null)
        {
            this._mediator = mediator;
        }

        public void SetMediator(IMediator mediator)
        {
            this._mediator = mediator;
        }
    }   
}