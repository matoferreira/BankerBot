using NUnit.Framework;

namespace Library.Test
{
    public class ConsolePrinterTests
    {
        private string linea;
        private ConsolePrinter Printer;
        [SetUp]
        public void Setup()
        {
            linea = "Juan hols#Hola#jjj   gtgd##";
            Printer = new ConsolePrinter();
            Printer.PrintLine(linea);

        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(1, 2);
        }
    }
}