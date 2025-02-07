namespace Itmo.ObjectOrientedProgramming.Lab4;

public interface IFileSystemHandler
{
       public void AddToDictionary(string textOfCommand, ICommand commandFromHandler);
       public void DefineCommand();
       public void RunCommand(ICommand commandFromHandler);
}