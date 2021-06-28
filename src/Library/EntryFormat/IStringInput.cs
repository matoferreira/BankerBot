using System;
// IStringImput y IIntImput cumplen con ISP pues se utilizan pequeñas interfases para implemaentar solo el comportamiento
//que las clases necesitan, en lugar de acumularlo todo en IEntryFormat
namespace Library
{
    public interface IStringInput : IEntryFormat
    {
        string GetInput(string message);
    }
}