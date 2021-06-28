using System;

namespace Library
{
    public interface IIntInput : IEntryFormat
    {
        int GetInput(string message);
    }
}