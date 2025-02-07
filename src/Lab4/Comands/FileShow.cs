using System;
using System.Collections.Generic;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class FileShow : ICommand
{
    private ExceptionCollector _exceptionCollector = new ExceptionCollector();
    public void DoCommand(IReadOnlyList<string> args)
    {
        try
        {
           if (args == null) throw new ArgumentNullException(nameof(args));
           ValueVerificator.NullStringValueByParts(args, 4);
           if (!File.Exists(args[2])) throw new ArgumentException("File doesn't doesnt exist.");
           File.ReadAllLines(args[2]);
        }
        catch (ArgumentException exception)
        {
             _exceptionCollector.AddExceptionToList(exception.Message);
        }
    }
}