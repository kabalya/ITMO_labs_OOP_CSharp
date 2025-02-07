using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class ValueVerificator
{
    public static void NullStringValue(string value)
    {
        if (value is null)
        {
            throw new ArgumentException("String can't be null ");
        }
    }

    public static void NullStringValueByParts(IReadOnlyList<string> value, int numberOfPartsToCheck)
    {
        if (value is null) throw new ArgumentException("String can't be null.");
        for (int i = 0; i < numberOfPartsToCheck; i++)
        {
            if (value[i] is null) throw new ArgumentException("String can't be null.");
        }
    }

    public static void NegativeValue(int value)
    {
        if (value < 0) throw new ArgumentException("Value Can't be Negative Value");
    }
}