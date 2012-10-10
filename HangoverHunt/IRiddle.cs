using System;
namespace HangoverHunt
{
    public interface IRiddle
    {
        bool CheckAnswer(IAnswer answer);
        string Question { get; }
    }
}
