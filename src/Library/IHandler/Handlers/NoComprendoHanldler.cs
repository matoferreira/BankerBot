using System;

namespace Library
{
    public class NoComprendoHandler : AbstractHandler
    {
        public override object Handle(Request request)
        {
            {
                return "No comprendo lo que dices 😕";
            }
        }
    }
}