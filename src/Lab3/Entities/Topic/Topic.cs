using System;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Topic
{
    private MistakesCollector _mistakesCollector = new MistakesCollector();
    public Topic(string name, IAddresat addresat)
    {
        Name = name;
        Addresat = addresat;
    }

    public string Name { get; private set; }
    public IAddresat Addresat { get; private set; }
    public void InputMessage(Message message)
    {
        try
        {
            WrongValueValidator.NullMessageError(message);
            Addresat.InputMessage(message);
        }
        catch (ArgumentException exception)
        {
            _mistakesCollector.ListAddError(exception.Message);
        }
    }
}