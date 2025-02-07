using System;
using System.Collections.Generic;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class FileDelete : ICommand
{
    private ExceptionCollector _exceptionCollector = new ExceptionCollector();
    public void DoCommand(IReadOnlyList<string> args)
    {
        try
        {
          if (args == null) throw new ArgumentNullException(nameof(args));
          ValueVerificator.NullStringValueByParts(args, 2);
          if (!File.Exists(args[2]))
          {
              throw new ArgumentException("You Can't delete something if this something doesn't exist.");
          }
          else
          {
               File.Delete(args[2]);
          }
        }
        catch (ArgumentException exception)
        {
            _exceptionCollector.AddExceptionToList(exception.Message);
        }
    }
}