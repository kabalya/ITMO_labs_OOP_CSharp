namespace BankProject;

public class CreateAccountPrint : IUserComand
{
    private readonly string name;
    private readonly string password;
    private readonly IUserInformation printer;

    public CreateAccountPrint(string password, string name, IUserInformation printer)
    {
        this.password = password;
        this.name = name;
        this.printer = printer;
    }

    public void Execute(ISession session, IAccountStorage accountStorage)
    {
        if (session is null) throw new ArgumentException("Wrong Argument");
        if (accountStorage is null) throw new ArgumentException("Wrong Argument");
        Account account = accountStorage.CreateAccount(password, name);
        printer.Print(account);
    }
}