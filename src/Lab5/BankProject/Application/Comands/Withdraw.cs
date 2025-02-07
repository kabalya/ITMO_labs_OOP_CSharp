namespace BankProject;

public class Withdraw : IUserComand
{
    private readonly CashVerificator _cashVerificator;
    private readonly long id;

    public Withdraw(long id, CashVerificator cashVerificator)
    {
        this.id = id;
        this._cashVerificator = cashVerificator;
    }

    public void Execute(ISession session, IAccountStorage accountStorage)
    {
        if (session is null) throw new ArgumentException(" Wrong Argument");
        if (accountStorage is null) throw new ArgumentException(" Wrong Argument");
        if (!session.IsAvailable(id))
        {
            throw new ArgumentException("String can't be null ");
        }

        Account? account = accountStorage.FindAccount(id);
        if (account == null)
        {
            throw new ArgumentException("Account didnt find");
        }

        accountStorage.CreateTransaction(id, TypeOfTransaction.Withdraw, _cashVerificator.Value);

        account.DecreaseMoney(_cashVerificator);
        accountStorage.SaveAccount(account);
    }
}