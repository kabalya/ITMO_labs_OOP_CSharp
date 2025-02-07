namespace BankProject;

public class InfoComandPrint : IUserComand
{
    private readonly long id;
    private readonly IUserInformation printer;

    public InfoComandPrint(long id, IUserInformation printer)
    {
        this.id = id;
        this.printer = printer;
    }

    public void Execute(ISession session, IAccountStorage accountStorage)
    {
        ArgumentNullException.ThrowIfNull(session);
        ArgumentNullException.ThrowIfNull(accountStorage);

        if (!session.IsAvailable(id))
        {
            throw new ArgumentException("Id Exception");
        }

        Account? account = accountStorage.FindAccount(id);
        if (account == null)
        {
            throw new ArgumentException("Account didnt find");
        }

        printer.Print(account);
    }
}