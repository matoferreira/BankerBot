using System;

namespace Library
{
    public class SavingsAnalysisHandler : AbstractHandler
    {
        public override object Handle(Request request)
        {
            if (request.Content == "/mostrarahorros")
            {
                return "Falta implementar funcion";
            }
            else
            {
                return base.Next.Handle(request);
            }
        }
    }
}