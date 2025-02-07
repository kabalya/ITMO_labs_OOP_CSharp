using System;
using static Crayon.Output;
namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Display
{
    private MistakesCollector _mistakesCollector = new MistakesCollector();
    public static void ClearSpace()
    {
        Console.Clear();
    }

    public void Print(byte r, byte g, byte b, Message message)
    {
        ClearSpace();
        try
        {
            WrongValueValidator.NullMessageError(message);
            WrongValueValidator.VerificationValueIsInAlowedRange(0, r, 255);
            WrongValueValidator.VerificationValueIsInAlowedRange(0, g, 255);
            WrongValueValidator.VerificationValueIsInAlowedRange(0, b, 255);
            Console.WriteLine(Rgb(r, g, b).Text(message.Title + message.Body));
        }
        catch (ArgumentException exception)
        {
            _mistakesCollector.ListAddError(exception.Message);
        }
    }
}