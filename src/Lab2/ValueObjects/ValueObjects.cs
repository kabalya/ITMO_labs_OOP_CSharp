using System;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ValueObjects
{
    private int count;
    public void AddCheckMinusValue(int value)
    {
        if (value < 0)
        {
            count++;
            throw new ArgumentException("Value Can not be minus value");
        }
    }
}