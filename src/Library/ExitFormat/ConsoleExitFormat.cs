using System;

namespace Library
{
    //Exitformat es una interface, lo que buscamos con esto es, por el principio de LSP,
    //poder tener un programa que cumpla con el principio de OCP. La forma en que se cumple OCP es que,
    //implementando una interface como formato de salida, podemos agregar nuevas APIs de comunicaciones (abierto a la extensión)
    //sin tener que modificar el comportamiento del programa (cerrado a la modificación). Ya que el programa va a esperar un objeto
    //del tipo IExitFormat pudiendo ser substituido por cualquier subtipo de ésta (LSP).
    public class ConsoleExitFormat : IPrinter
    {
        public IEntryFormat EntryFormat { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void PrintLine(string line)
        {
            throw new NotImplementedException();
        }
    }
    /*public string GetTextToPrint()
        {
            string result = $"Receta de {this.FinalProduct.Description}:\n";
            foreach (BaseStep step in this.steps)
            {
                result = result + step.GetTextToPrint() + "\n";
            }

            // Agregado por Expert
            result = result + $"Costo de producción: {this.GetProductionCost()}";

            return result;
        }
        */
}