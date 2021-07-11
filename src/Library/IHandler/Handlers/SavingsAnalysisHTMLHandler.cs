using System;
using System.Collections.Generic;
using Aspose.Html;

namespace Library
{
    public class SavingsAnalysisHTMLHandler : AbstractHandler
    {
        public override void Handle(Request request)
        {
            if (request.Content == "/mostrarahorros")
            {
                HtmlDocument doc = new HtmlDocument("AnalisisdeAhorro.html", "BankerBot");
                doc.AddContent(new Span("Análisis de Ahorro"));
                doc.AddContent(new Table
                (
                    new HeaderRow(
                        new List<HeaderCell>() 
                        {
                            new HeaderCell($"Resumen de cuentas y ahorro al día {DateTime.Now}"),
                        }),
                    new List<Row>()
                    {
                        new Row(new List<Cell>()
                        {
                            new Cell ("Método de pago"),
                            new Cell ("Saldo")
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
                            new FooterCell($"{request.Profile.TotalBalance()}")
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