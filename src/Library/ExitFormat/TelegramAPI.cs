using System;

namespace Library
{
    //TelegramAPI se crea como un objeto del tipo IExitFormat para poder cumplir con la justificación brindada en IExitFormat.
    public class TelegramAPI : IExitFormat
    {
        public IEntryFormat EntryFormat { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}