namespace BankProject;

public class ConsoleAdminBalance : IUserInformation
{
    public void Print(Account account)
    {
        if (account is null) throw new ArgumentException(" Wrong argument");
        System.Console.WriteLine("Balance = " + account.Balance);
    }
}