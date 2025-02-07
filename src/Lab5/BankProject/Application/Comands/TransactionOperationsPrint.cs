namespace BankProject;

public class TransactionOperationsPrint : IUserComand
{
    private readonly long id;
    private readonly ITransactionInfoPrinter printer;

    public TransactionOperationsPrint(long id, ITransactionInfoPrinter printer)
    {
        this.id = id;
        this.printer = printer;
    }

    public void Execute(ISession session, IAccountStorage accountStorage)
    {
        if (session is null) throw new ArgumentException("Wrong Argument");
        if (accountStorage is null) throw new ArgumentException("Wrong Argument");
        if (!session.IsAvailable(id)) throw new ArgumentException("Id Exception ");
        Account? account = accountStorage.FindAccount(id);
        if (account == null) throw new ArgumentException("Cant find this Inputed Information");

        IReadOnlyList<Transaction> transactions = accountStorage.Transactions(id, 10);
        foreach (Transaction transaction in transactions)
        {
            printer.Print(transaction);
        }
    }
}