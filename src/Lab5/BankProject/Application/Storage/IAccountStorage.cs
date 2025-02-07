namespace BankProject;

public interface IAccountStorage
{
    public Account CreateAccount(string password, string name);
    public void DeleteAccount(Account account);
    public Account? FindAccount(long id);
    public void SaveAccount(Account account);
    public Transaction CreateTransaction(long id, TypeOfTransaction type, long amountOfCash);

    public IReadOnlyList<Transaction> Transactions(long id, int limit);
}