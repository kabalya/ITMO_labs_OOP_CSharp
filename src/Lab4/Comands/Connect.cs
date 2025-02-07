using System;
using System.Collections.Generic;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Connect : ICommand
{
    private ExceptionCollector _exceptionCollector = new ExceptionCollector();
    public void DoCommand(IReadOnlyList<string> args)
    {
        try
        {
            if (args == null) throw new ArgumentException("Null Exception ");
            ValueVerificator.NullStringValueByParts(args, 3);
            if (!Directory.Exists(args[1])) throw new ArgumentException("Directory Doesn't exist.");
            Directory.SetCurrentDirectory(args[1]);
        }
        catch (ArgumentException exception)
        {
             _exceptionCollector.AddExceptionToList(exception.Message);
        }
    }
}