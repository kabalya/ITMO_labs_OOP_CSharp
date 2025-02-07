using System;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Messanger
{
    private MistakesCollector _mistakesCollector = new MistakesCollector();
    public Messanger(IPrinter printer)
    {
        Printer = printer;
    }

    public IPrinter Printer { get; private set; }
    public bool IsExpectingValue { get; private set; }

    public void InputMessage(Message message)
    {
        try
        {
            WrongValueValidator.NullMessageError(message);
            Printer?.Print(message);
            IsExpectingValue = true;
        }
        catch (ArgumentException exception)
        {
            _mistakesCollector.ListAddError(exception.Message);
        }
    }
}