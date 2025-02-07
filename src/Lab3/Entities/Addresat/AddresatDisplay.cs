using System;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class AddresatDisplay : IAddresat
{
    private MistakesCollector _mistakesCollector = new MistakesCollector();
    private Display display = new Display();
    private byte _r;
    private byte _g;
    private byte _b;

    public AddresatDisplay(int importanceAddresatFilter, Display display, byte b, byte r, byte g)
    {
        WrongValueValidator.NegativeValueError(importanceAddresatFilter);
        ImportanceAddresatFilter = importanceAddresatFilter;
        this.display = display;
        _r = r;
        _g = g;
        _b = b;
    }

    public int ImportanceAddresatFilter { get; }
    public int BusinessCountOfAddresatInputMessages { get; private set; }

    public void InputMessage(Message message)
    {
        try
        {
            WrongValueValidator.NullMessageError(message);
            WrongValueValidator.VerificationValueIsInAlowedRange(0, _r, 255);
            WrongValueValidator.VerificationValueIsInAlowedRange(0, _g, 255);
            WrongValueValidator.VerificationValueIsInAlowedRange(0, _b, 255);
            if (message.Importance >= ImportanceAddresatFilter)
            {
                BusinessCountOfAddresatInputMessages++;
                Display.ClearSpace();
                display.Print(_r, _g, _b, message);
            }
        }
        catch (ArgumentException exception)
        {
            _mistakesCollector.ListAddError(exception.Message);
        }
    }
}