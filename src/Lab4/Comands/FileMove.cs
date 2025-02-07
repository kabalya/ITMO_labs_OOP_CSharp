using System;
using System.Collections.Generic;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class FileMove : ICommand
{
    private ExceptionCollector _exceptionCollector = new ExceptionCollector();
    public void DoCommand(IReadOnlyList<string> args)
    {
        try
        {
           if (args == null) throw new ArgumentNullException(nameof(args));
           ValueVerificator.NullStringValueByParts(args, 3);
           if (File.Exists(args[3])) throw new ArgumentException("Sorry, but here is existing file on your path.");
           if (!File.Exists(args[2])) throw new ArgumentException("Sorry but you can't move empty space ;) ");
           File.Move(args[2], args[3]);
        }
        catch (ArgumentException exception)
        {
             _exceptionCollector.AddExceptionToList(exception.Message);
        }
    }
}