using System;
using System.Collections.Generic;
using System.IO;
namespace Itmo.ObjectOrientedProgramming.Lab4;

public class FileCopy : ICommand
{
    private ExceptionCollector _exceptionCollector = new ExceptionCollector();
    public void DoCommand(IReadOnlyList<string> args)
    {
        try
        {
            if (args == null) throw new ArgumentNullException(nameof(args));
            ValueVerificator.NullStringValueByParts(args, 3);
            if (File.Exists(args[3])) throw new ArgumentException("Sorry , You are awesome but file already exsist.");
            File.Copy(args[2], args[3]);
        }
        catch (ArgumentException exception)
        {
             _exceptionCollector.AddExceptionToList(exception.Message);
        }
    }
}