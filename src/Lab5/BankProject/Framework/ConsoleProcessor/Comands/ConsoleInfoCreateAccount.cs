namespace BankProject;

public class ConsoleInfoCreateAccount : IUserInformation
{
    public void Print(Account account)
    {
        if (account is null) throw new ArgumentException(" Wrong argument");
        System.Console.WriteLine("New account name = " + account.Name + " , ID= " + account.Id);
    }
}