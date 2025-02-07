using System;
using System.Collections.Generic;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class TreeGoTo : ICommand
{
    private ExceptionCollector _exceptionCollector = new ExceptionCollector();
    public void DoCommand(IReadOnlyList<string> args)
    {
        try
        {
           if (args == null) throw new ArgumentNullException(nameof(args));
           if (!Directory.Exists(args[2]))
           {
               throw new ArgumentException("You Can't delete something if this something doesnt exist.");
           }
           else
           {
                Environment.CurrentDirectory = args[2];
           }
        }
        catch (ArgumentException exception)
        {
            _exceptionCollector.AddExceptionToList(exception.Message);
        }
    }
}