using System;

namespace Library
{
    public class SavingsAnalysisHandler : AbstractHandler
    {
        public override void Handle(Request request)
        {
            if (request.Content == "/mostrarahorros")
            {
                //Acá va la integración con la API de HTML
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}