using System;

namespace Library
{
    public interface IHandler
    {
        IHandler Next { get; }

        void Handle(Request request);
    }
}