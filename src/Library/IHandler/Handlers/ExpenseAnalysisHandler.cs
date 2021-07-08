using System;

namespace Library
{
    public class ExpenseAnalysisHandler : AbstractHandler
    {
        public override void Handle(Request request)
        {
            if (request.Content == "/mostrargastos")
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