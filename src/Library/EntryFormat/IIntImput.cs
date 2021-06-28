using System;
// IStringImput y IIntImput cumplen con ISP pues se utilizan pequeñas interfases para implemaentar solo el comportamiento
//que las clases necesitan, en lugar de acumularlo todo en IEntryFormat.
//Cumple con DIP pues la comunicación es con clases de alto  nivel.
namespace Library
{
    public interface IIntImput : IEntryFormat
    {
        int GetImput(string message);
    }
}