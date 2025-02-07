using System;
namespace Itmo.ObjectOrientedProgramming.Lab3;

public class ConsolePrinter : IPrinter
{
    private MistakesCollector _mistakesCollector = new MistakesCollector();
    public void Print(Message message)
    {
        try
        {
            WrongValueValidator.NullMessageError(message);
            Console.WriteLine("Messanger  " + message.Title + "\n" + message.Body);
        }
        catch (ArgumentException exception)
        {
            _mistakesCollector.ListAddError(exception.Message);
        }
    }
}