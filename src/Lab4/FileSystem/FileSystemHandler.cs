using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class FileSystemHandler : IFileSystemHandler
{
    private Parser parser;
    private Dictionary<string, ICommand> commandsDictionary = new Dictionary<string, ICommand>()
    {
        { "connect", new Connect() },
        { "disconnect", new Disconnect() },
        { "file copy", new FileCopy() },
        { "file delete", new FileDelete() },
        { "tree goto", new TreeGoTo() },
        { "file move", new FileMove() },
        { "file rename", new FileRename() },
        { "file show", new FileShow() },
        { "tree list", new TreeList() },
    };
    private ExceptionCollector _exceptionCollector = new ExceptionCollector();
    public FileSystemHandler(Parser parser)
    {
        this.parser = parser ?? throw new ArgumentNullException(nameof(parser));
    }

    public ICommand? CommandFromHandler { get; private set; }

    public void AddToDictionary(string textOfCommand, ICommand commandFromHandler)
    {
        try
        {
            ValueVerificator.NullStringValue(textOfCommand);
            if (commandFromHandler == null) throw new ArgumentNullException(nameof(commandFromHandler));
            if (!commandsDictionary.ContainsKey(textOfCommand))
            {
                commandsDictionary.Add(textOfCommand, commandFromHandler);
            }
            else
            {
                throw new ArgumentException("This Command Already exist", nameof(textOfCommand));
            }
        }
        catch (ArgumentException ex)
        {
            _exceptionCollector.AddExceptionToList(ex.Message);
        }
    }

    public void DefineCommand()
    {
        try
        {
            if (parser.CommandText != null && commandsDictionary.TryGetValue(parser.CommandText, out ICommand? commandFromHandler))
            {
                CommandFromHandler = commandFromHandler;
            }
            else
            {
                throw new ArgumentException("Sorry, You just inputed wrong comand");
            }
        }
        catch (ArgumentException ex)
        {
            _exceptionCollector.AddExceptionToList(ex.Message);
        }
    }

    public void RunCommand(ICommand commandFromHandler)
    {
        try
        {
            if (commandFromHandler == null) throw new ArgumentNullException(nameof(commandFromHandler));
            if (parser.SeparatedTextofCommand != null) commandFromHandler.DoCommand(parser.SeparatedTextofCommand);
            else throw new ArgumentException("Text after separation Can't be NULL, Please Check and fix your input");
        }
        catch (ArgumentException ex)
        {
            _exceptionCollector.AddExceptionToList(ex.Message);
        }
    }
}