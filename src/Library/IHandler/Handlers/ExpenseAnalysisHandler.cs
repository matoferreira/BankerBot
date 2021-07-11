using System;

namespace Library
{
    public class ExpenseAnalysisHandler : AbstractHandler
    {
        public override void Handle(Request request)
        {
            if (request.Content == "/mostrargastos")
            {
                var expenseTypes = UserProfile.ExpenseTypes;
                request.Profile.ExpenseAnalysis.CalculateTotalByType(request.Profile.PaymentMethods,
                                                                     expenseTypes);
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}