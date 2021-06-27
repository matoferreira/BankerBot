using System;

namespace Library
{
    public interface IIntImput : IEntryFormat
    {
        int GetImput(string message);
    }
}