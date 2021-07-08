using System;

namespace Library
{
    public interface IHandler
    {
        IHandler Next { get; }

        object Handle(Request request);
    }
}