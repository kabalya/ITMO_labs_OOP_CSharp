namespace BankProject;

public static class ConsoleRun
{
    public static void Main()
    {
        IAccountStorage accountStorage = new DataBaseOperations("localhost:1605", "kabalya", "VladPovishev", "DataBaseTest");
        var consoleUser = new ConsoleUser(accountStorage, "oralcomeshot");
        consoleUser.OpenSession();
    }
}