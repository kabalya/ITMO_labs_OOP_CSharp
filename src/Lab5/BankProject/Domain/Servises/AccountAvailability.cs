namespace BankProject;

public class AccountAvailability : ISession
{
    private readonly Account _account;

    public AccountAvailability(Account account)
    {
        this._account = account;
    }

    public bool IsAvailable(long id)
    {
        return _account.Id == id;
    }
}