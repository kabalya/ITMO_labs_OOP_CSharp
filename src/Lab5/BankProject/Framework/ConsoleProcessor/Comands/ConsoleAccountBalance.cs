namespace BankProject;

public class ConsoleAccountBalance : IUserInformation
{
    public void Print(Account account)
    {
        if (account is null) throw new ArgumentException(" Wrong argument");
        System.Console.WriteLine("Your balance: " + account.Balance);
    }
}