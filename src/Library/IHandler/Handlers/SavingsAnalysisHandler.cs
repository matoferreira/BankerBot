using System;

namespace Library
{
    public class SavingsAnalysisHandler : AbstractHandler
    {
        public override void Handle(Request request)
        {
            if (request.Content == "/mostrarahorros")
            {
                request.Profile.SavingsAnalysis.AnalyseSavings(request.Profile.PaymentMethods);
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}