using System;

namespace Library
{
    public class SavingsAnalysisHandler : AbstractHandler
    {
        public IStringInput StringImput = Singleton<ConsoleReader>.Instance;
        public override void Handle(Request request)
        {
            if (request.Content == "/MostrarResumenAhorros")
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