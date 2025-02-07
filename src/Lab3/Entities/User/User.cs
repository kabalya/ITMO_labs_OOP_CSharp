using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class User : IUser
{
    private List<Message> listOfMessages = new List<Message>();
    private MistakesCollector _mistakesCollector = new MistakesCollector();

    public void InputMessage(Message message)
    {
        try
        {
            WrongValueValidator.NullMessageError(message);
            listOfMessages.Add(message);
        }
        catch (ArgumentException exception)
        {
            _mistakesCollector.ListAddError(exception.Message);
        }
    }

    public void MarkAsRead(Message message)
    {
        foreach (Message msg in listOfMessages)
        {
            try
            {
                if (msg.Id == message?.Id && message?.IsRead == true)
                {
                    throw new ArgumentException("You can't mark as read what has already been read");
                }
            }
            catch (ArgumentException exception)
            {
                _mistakesCollector.ListAddError(exception.Message);
            }

            message?.MarkAsRead();
        }
    }

    public bool IsMessageNotReadYet(Message message)
    {
        foreach (Message msg in listOfMessages)
        {
            if (msg.Id == message?.Id && message?.IsRead == false)
            {
                return true;
            }

            return false;
        }

        return false;
    }
}