using System;
namespace Itmo.ObjectOrientedProgramming.Lab1;

public class JumpEngineValueObjects
{
    public int Length { get; private set; }
    public static void CatchMistakesOfLength(int value)
    {
        if (value < 0)
        {
            throw new InvalidOperationException("Length Can not be -Value");
        }
    }

    public void SetLength(int value)
    {
        Length = value;
    }
}