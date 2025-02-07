using System;
using System.Collections.Generic;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Disconnect : ICommand
{
    private ExceptionCollector _exceptionCollector = new ExceptionCollector();
    public void DoCommand(IReadOnlyList<string> args)
    {
        try
        {
            string[] beginning = System.IO.Directory.GetLogicalDrives();
            if (beginning is null) throw new ArgumentException("System Doesn't have Logical Drive");
            Directory.SetCurrentDirectory(beginning[0]);
        }
        catch (ArgumentException exception)
        {
             _exceptionCollector.AddExceptionToList(exception.Message);
        }
    }
}