using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class TreeList : ICommand
{
    private ExceptionCollector _exceptionCollector = new ExceptionCollector();
    public void DoCommand(IReadOnlyList<string> args)
    {
        if (args == null) throw new ArgumentNullException(nameof(args));
        ValueVerificator.NullStringValueByParts(args, 3);
        string[] files = GetFilesInDirectoryWithDepth(args[3], Convert.ToInt32(args[4], CultureInfo.CurrentCulture));

        foreach (string file in files)
        {
             Console.WriteLine(file);
        }
    }

    public string[] GetFilesInDirectoryWithDepth(string directoryPath, int maxDepth)
    {
        ValueVerificator.NegativeValue(maxDepth);
        ValueVerificator.NullStringValue(directoryPath);
        string[] files = Directory.GetFiles(directoryPath);

        if (maxDepth > 0)
        {
            string[] subDirectories = Directory.GetDirectories(directoryPath);
            foreach (string subDirectory in subDirectories)
            {
                try
                {
                    string[] subFiles = GetFilesInDirectoryWithDepth(subDirectory, maxDepth - 1);
                    files = files.Concat(subFiles).ToArray();
                }
                catch (UnauthorizedAccessException exception)
                {
                    _exceptionCollector.AddExceptionToList(exception.Message);
                }
            }
        }

        return files;
    }
}