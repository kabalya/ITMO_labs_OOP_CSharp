using System;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public static class WrongValueValidator
{
    public static void VerificationValueIsInAlowedRange(int firstBorder, int value, int secondBorder)
    {
        if (firstBorder > value || value > secondBorder)
        {
            throw new ArgumentException("Value Is not in allowed range ");
        }
    }

    public static void NullMessageError(Message message)
    {
        if (message is null) throw new ArgumentException("Message can't be null ");
        if (message.Body is null) throw new ArgumentException("Body can't be null ");
        if (message.Importance < 0) throw new ArgumentException("Importance level of Message can't be negative Value ");
    }

    public static void NullStringError(string value)
    {
        if (value is null)
        {
            throw new ArgumentException("String can't be null ");
        }
    }

    public static void NegativeValueError(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Value can't be negative ");
        }
    }
}