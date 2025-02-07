namespace BankProject;

public class AccountCreate : IUserComands
{
    private readonly IUserInformation printer;

    public AccountCreate(IUserInformation printer)
    {
        this.printer = printer;
    }

    public IUserComand Create(ParsedComand parsedComand)
    {
        if (parsedComand is null) throw new ArgumentException("Wrong Agument");

        string name = parsedComand.GetArgument(0);
        string password = parsedComand.GetArgument(1);

        return new CreateAccountPrint(password, name, printer);
    }
}