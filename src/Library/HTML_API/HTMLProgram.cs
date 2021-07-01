using System;
using System.Collections.Generic;
using Aspose.Html;

namespace Library
{
    class HTMLProgram
    {

        static void Main(string[] args)
        {
            HtmlDocument doc = new HtmlDocument("test.html", "BankerBot");
            doc.AddContent(new Span("TITULO"));
            doc.AddContent(new Table(
              new HeaderRow(
                new List<HeaderCell>() {
                    new HeaderCell("Encabezado 1"),
                    new HeaderCell("Encabezado 2",2),
                    new HeaderCell("Encabezado 3"),
                }),
              new List<Row>()
              {
                new Row(new List<Cell>() {
                    new Cell("a"),
                    new Cell("b",2),
                    new Cell("c")
                }),
                new Row(new List<Cell>() {
                    new Cell("d"),
                    new Cell("c",3)
                }),
                  new Row(new List<Cell>() {
                    new Cell("h",4),

                }),
                  new Row(new List<Cell>() {
                    new Cell("j"),
                    new Cell("k"),
                    new Cell("c"),
                    new Cell("l")
                }),
                  new Row(new List<Cell>() {
                    new Cell("m"),
                    new Cell("n"),
                    new Cell("c"),
                    new Cell("o")
                }),
                  new Row(new List<Cell>() {
                    new Cell("p"),
                    new Cell("q"),
                    new Cell("c"),
                    new Cell("r")
                })
              },
              new FooterRow(
                new List<FooterCell>() {
                    new FooterCell("footer 1",3),
                    new FooterCell("footer 2"),
                }))
              );

        }
    }
}