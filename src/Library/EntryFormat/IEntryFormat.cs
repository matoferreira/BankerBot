using System;

namespace Library
{
    //Entryformat es una interface, lo que buscamos con esto es, por el principio de LSP, poder tener más de un formato de entrada independiente del funcionamiento 
    //del programa, y poder tener un programa que cumpla con el principio de OCP. La forma en que se cumple OCP es que,
    //implementando una interface como formato de entrada, podemos agregar nuevas APIs de comunicaciones (abierto a la extensión)
    //sin tener que modificar el comportamiento del programa (cerrado a la modificación). Ya que el programa va a esperar un objeto
    //del tipo IEntryFormat pudiendo ser substituido por cualquier subtipo de ésta (LSP).
    public interface IEntryFormat
    {

    }
}