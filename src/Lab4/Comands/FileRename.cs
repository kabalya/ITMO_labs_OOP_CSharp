using System;
using System.Collections.Generic;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class FileRename : ICommand
{
    private ExceptionCollector _exceptionCollector = new ExceptionCollector();
    public void DoCommand(IReadOnlyList<string> args)
    {
        try
        {
          if (args == null) throw new ArgumentNullException(nameof(args));
          ValueVerificator.NullStringValueByParts(args, 3);
          if (File.Exists(args[2] + args[3])) throw new ArgumentException("File with same Name already exist, Plese add some letters to file name");
          if (!File.Exists(args[2])) throw new ArgumentException("File that you want to rename doesn't exist.");
          File.Copy(args[2], args[3], true);
          File.Delete(args[2]);
        }
        catch (ArgumentException exception)
        {
             _exceptionCollector.AddExceptionToList(exception.Message);
        }
    }
}