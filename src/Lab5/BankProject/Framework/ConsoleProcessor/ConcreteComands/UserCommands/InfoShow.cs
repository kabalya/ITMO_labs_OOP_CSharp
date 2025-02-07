namespace BankProject;

public class InfoShow : IUserComands
{
    private readonly long id;
    private readonly IUserInformation printer;

    public InfoShow(long id, IUserInformation printer)
    {
        this.id = id;
        this.printer = printer;
    }

    public IUserComand Create(ParsedComand parsedComand)
    {
        return new InfoComandPrint(id, printer);
    }
}