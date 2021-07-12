using System;

namespace Library
{
    public class NoComprendoHandler : AbstractHandler
    {
        public override void Handle(Request request)
        {
            {
                Output.PrintLine("No comprendo lo que dices 😕");
            }
        }
    }
}