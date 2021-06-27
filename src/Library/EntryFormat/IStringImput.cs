using System;

namespace Library
{
    public interface IStringImput : IEntryFormat
    {
        string GetImput(string message);
    }
}