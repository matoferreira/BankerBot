using System;

namespace Library
{
    public class ExpenseAnalysisHandler: AbstractHandler
    {
        public IStringInput StringImput = Singleton<ConsoleReader>.Instance;
        public override void Handle(Request request)
        {
            if (request.Content == "/MostrarResumenGastos")
            {
                
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}