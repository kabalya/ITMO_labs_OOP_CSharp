using System;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class AddresatUser : IAddresat
{
    private MistakesCollector _mistakesCollector = new MistakesCollector();
    private User user = new User();
    public AddresatUser(int importanceAddresatFilter, User user)
    {
        WrongValueValidator.NegativeValueError(importanceAddresatFilter);
        ImportanceAddresatFilter = importanceAddresatFilter;
        this.user = user;
    }

    public int ImportanceAddresatFilter { get; }
    public int BusinessCountOfAddresatInputMessages { get; private set; }

    public void InputMessage(Message message)
    {
        try
        {
            if (message?.Importance >= ImportanceAddresatFilter)
            {
                WrongValueValidator.NullMessageError(message);
                user.InputMessage(message);
                BusinessCountOfAddresatInputMessages++;
            }
        }
        catch (ArgumentException exception)
        {
            _mistakesCollector.ListAddError(exception.Message);
        }
    }
}