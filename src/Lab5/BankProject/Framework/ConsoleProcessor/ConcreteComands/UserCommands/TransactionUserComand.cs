namespace BankProject;

public class TransactionUserComand : IUserComands
{
    private readonly long id;
    private readonly ITransactionInfoPrinter printer;

    public TransactionUserComand(long id, ITransactionInfoPrinter printer)
    {
        this.id = id;
        this.printer = printer;
    }

    public IUserComand Create(ParsedComand parsedComand)
    {
        return new TransactionOperationsPrint(id, printer);
    }
}