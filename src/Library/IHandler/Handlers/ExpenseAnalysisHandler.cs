using System;

namespace Library
{
    public class ExpenseAnalysisHandler : AbstractHandler
    {
        public override object Handle(Request request)
        {
            if (request.Content == "/mostrargastos")
            {
                return "Falta implementar";
            }
            else
            {
                return base.Next.Handle(request);
            }
        }
    }
}