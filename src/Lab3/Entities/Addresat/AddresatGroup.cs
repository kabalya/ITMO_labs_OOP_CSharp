using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class AddresatGroup : IAddresat
{
    private MistakesCollector _mistakesCollector = new MistakesCollector();
    private List<IAddresat> _listOfAddresats = new List<IAddresat>();
    public void AddAddresat(IAddresat addresat)
    {
        try
        {
            if (addresat == null) throw new ArgumentException("Addresat can't be null if you are using this method");
            _listOfAddresats.Add(addresat);
        }
        catch (ArgumentException exception)
        {
            _mistakesCollector.ListAddError(exception.Message);
        }
    }

    public void RemoveAddresat(IAddresat addresat)
    {
        try
        {
            if (addresat == null) throw new ArgumentException("Addresat can't be null if you are using this method");
            _listOfAddresats.Remove(addresat);
        }
        catch (ArgumentException exception)
        {
            _mistakesCollector.ListAddError(exception.Message);
        }
    }

    public void InputMessage(Message message)
    {
        try
        {
            WrongValueValidator.NullMessageError(message);
            foreach (IAddresat ads in _listOfAddresats)
            {
                ads.InputMessage(message ?? throw new ArgumentNullException(nameof(message)));
            }
        }
        catch (ArgumentException exception)
        {
            _mistakesCollector.ListAddError(exception.Message);
        }
    }
}