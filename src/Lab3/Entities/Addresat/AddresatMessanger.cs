using System;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class AddresatMessanger : IAddresat
{
    private MistakesCollector _mistakesCollector = new MistakesCollector();
    public AddresatMessanger(int importanceAddresatFilter, Messanger messanger)
    {
        WrongValueValidator.NegativeValueError(importanceAddresatFilter);
        ImportanceAddresatFilter = importanceAddresatFilter;
        Messanger = messanger;
    }

    public Messanger Messanger { get; }
    public int ImportanceAddresatFilter { get; }
    public int BusinessCountOfAddresatInputMessages { get; private set; }

    public void InputMessage(Message message)
    {
        try
        {
            WrongValueValidator.NullMessageError(message);
            if (message.Importance >= ImportanceAddresatFilter)
            {
                Messanger.InputMessage(message);
                BusinessCountOfAddresatInputMessages++;
            }
        }
        catch (ArgumentException exception)
        {
            _mistakesCollector.ListAddError(exception.Message);
        }
    }
}