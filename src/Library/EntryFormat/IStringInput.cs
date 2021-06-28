using System;

namespace Library
{
    public interface IStringInput : IEntryFormat
    {
        string GetInput(string message);
    }
}