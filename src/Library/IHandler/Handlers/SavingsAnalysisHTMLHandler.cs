//Agregar comentarios:
//Menos acoplado porque el total se calcula en el IF
//Que solucionamos el problema haciendo el foreach afuera de la tabla

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
                double total = 0;
                HtmlDocument doc = new HtmlDocument("AnalisisdeAhorro.html", "BankerBot");
                doc.AddContent(new Span("Análisis de Ahorro"));
                List<Row> resultado = new List<Row>();
                resultado.Add(new Row(new List<Cell>()
                        {
                            new Cell ("Método de pago"),
                            new Cell ("Saldo")
                        }));
                foreach (PaymentMethod item in request.Profile.PaymentMethods)
                {
                    resultado.Add(new Row(new List<Cell>() 
                            {
                                new Cell($"{item.Name}"),
                                new Cell($"{item.GetBalance()}")
                            }));
                    total = total + item.GetBalance();
                }
                doc.AddContent(new Table
                (
                    new HeaderRow(
                        new List<HeaderCell>() 
                        {
                            new HeaderCell($"Resumen de cuentas y ahorro al día {DateTime.Now}"),
                        }),

                    resultado,

                    new FooterRow
                    (
                        new List<FooterCell>()
                        {
                            new FooterCell ("Total"),
                            new FooterCell($"{total}")
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