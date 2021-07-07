using System;

namespace Library
{
    public interface IHandler
    {
        IHandler Next { set; }

        void Handle(Request request);
    }
}