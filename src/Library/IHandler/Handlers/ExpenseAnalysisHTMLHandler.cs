//El propósito de este Handler es, utilizando la API de HTML, generar los reportes de los gastos.
//Para esto, implementamos un método que recorriera los tipos de gastos que existen en cada métodos de pago que tiene el usuario.
//Procuramos hacerlo de esta manera, ya que generamos que este menos acoplado y que la tabla se genere específicamente por los rubros en los que ha gastado cada usuario,
//evitando que nuestro código se pueda romper fácilmente por generar una estructura explícita totalmente (lo que da un grado de rigidez muy grande).
//Esta clase cumple con SRP porque su única razón de cambio es como se genera la tabla.
//A su vez, cumple con el patrón Expert porque es esta clase quien calcula el total que se coloca en el footer de la tabla,
//esto se obtiene al tener una variable total que, cada vez que se agrega un entero a una celda, se suma a esta variable que, al final del método,
//nos entrega el valor total sin necesidad de estar creando un método en el perfil del usuario para calcularlo.


using System;
using System.Collections.Generic;
using Aspose.Html;


namespace Library
{
    public class ExpenseAnalysisHTMLHandler : AbstractHandler
    {
        public override void Handle(Request request)
        {
            if (request.Content == "/mostrargastosHTML")
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