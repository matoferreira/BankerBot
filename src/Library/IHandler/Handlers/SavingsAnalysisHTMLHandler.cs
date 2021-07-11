//El propósito de este Handler es, utilizando la API de HTML, generar los reportes de los ahorros.
//Para esto, implementamos un método que recorriera los métodos de pago que tiene el usuario obteniendo nombre y balance de los mismos.
//Procuramos hacerlo de esta manera, ya que generamos que este menos acoplado y que la tabla se genere específicamente por lo que tiene cada usuario,
//evitando que nuestro código se pueda romper fácilmente por eso.
//Esta clase cumple con SRP porque su única razón de cambio es como se genera la tabla.
//A su vez, cumple con el patrón Expert porque es esta clase quien calcula el total que se coloca en el footer de la tabla,
//esto se obtiene al tener una variable total que, cada vez que se agrega un entero a una celda, se suma a esta variable que, al final del método,
//nos entrega el valor total sin necesidad de estar creando un método en el perfil del usuario para calcularlo.

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