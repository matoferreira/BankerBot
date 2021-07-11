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
              HtmlDocument doc = new HtmlDocument("AnalisisdeGastos.html", "BankerBot");
                doc.AddContent(new Span("Análisis de Gastos"));
                doc.AddContent(new Table
                (
                    new HeaderRow(
                        new List<HeaderCell>() 
                        {
                            new HeaderCell($"Resumen de gastos por rubro al día {DateTime.Now}"),
                        }),
                    new List<Row>()
                    {
                        new Row(new List<Cell>()
                        {
                            new Cell ("Rubro de Gasto"),
                            new Cell ("Total por rubro")
                        }),
                        /*foreach (PaymentMethod item in request.Profile.PaymentMethods)
                        {
                            new Row(new List<Cell>() 
                            {
                                new Cell($"{item}"),
                                new Cell($"{item.GetBalance()}")
                            });
                        }*/
                    },
                    new FooterRow
                    (
                        new List<FooterCell>()
                        {
                            new FooterCell ("Total"),
                            new FooterCell ($"{request.Profile.TotalExpense()}")
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