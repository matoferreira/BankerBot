using System;

namespace Library
{
    public class NoComprendoHandler : AbstractHandler
    {
        public override void Handle(Request request)
        {
            {
                Output.PrintLine("{chatInfo.FirstName}, no comprendo lo que dices 😕");

                base.Handle(request);
                //this.Next.Handle(request);
            }
        }
    }
}