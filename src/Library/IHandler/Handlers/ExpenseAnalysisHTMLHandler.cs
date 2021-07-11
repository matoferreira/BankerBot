using System;
using System.Collections.Generic;
using Aspose.Html;


namespace Library
{
    public class ExpenseAnalysisHTMLHandler : AbstractHandler
    {
        public override void Handle(Request request)
        {
            if (request.Content == "/mostrargastos")
            {
                double total = 0;
                HtmlDocument doc = new HtmlDocument("AnalisisdeGastos.html", "BankerBot");
                doc.AddContent(new Span("Análisis de Gastos"));
                List<Row> resultado = new List<Row>();
                resultado.Add(new Row(new List<Cell>()
                        {
                            new Cell ("Rubro de Gasto"),
                            new Cell ("Total por rubro")
                        }));
                foreach (ExpenseType expenseType in UserProfile.ExpenseTypes)
                {
                    double subtotal = 0;
                    foreach (PaymentMethod item in request.Profile.PaymentMethods)
                    {
                        if (typeof(Wallet).IsInstanceOfType(item))
                        {
                            foreach (SubWallet subwallet in ((Wallet)item).SubWalletList)
                            {
                                foreach (Transactions transaction in subwallet.Statement.Transactions)
                                {
                                    if (transaction.IsPositive == false)
                                    {
                                        if (((Expense)transaction).ExpenseType == expenseType)
                                        {
                                            subtotal = subtotal + transaction.Ammount*transaction.Currency.ExchangeRate;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (Transactions transaction in item.CurrentStatement.Transactions)
                            {
                                if (transaction.IsPositive == false)
                                {
                                    if (((Expense)transaction).ExpenseType == expenseType)
                                    {
                                        subtotal = subtotal + transaction.Ammount*transaction.Currency.ExchangeRate;
                                    }
                                }
                            }
                        }
                    }
                    resultado.Add(new Row(new List<Cell>() 
                            {
                                new Cell($"{ExpenseType.Name}"),
                                new Cell($"{subtotal}")
                            }));
                        total = total + subtotal;
                }
                doc.AddContent(new Table
                (
                    new HeaderRow(
                        new List<HeaderCell>() 
                        {
                            new HeaderCell($"Resumen de gastos por rubro al día {DateTime.Now}"),
                        }),
                    
                    resultado,

                    new FooterRow
                    (
                        new List<FooterCell>()
                        {
                            new FooterCell ("Total"),
                            new FooterCell ($"{total}")
                        }
                    ))
                );
            }
            else
            {
                this.Next.Handle(request);
            }
        }
    }
}