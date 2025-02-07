namespace BankProject;

public class DoDeposit : IUserComand
{
    private readonly CashVerificator _cashVerificator;
    private readonly long id;
    public DoDeposit(long id, CashVerificator cashVerificator)
    {
        this.id = id;
        this._cashVerificator = cashVerificator;
    }

    public void Execute(ISession session, IAccountStorage accountStorage)
    {
        if (session is null) throw new ArgumentException("Wrong Argument");
        if (accountStorage is null) throw new ArgumentException("Wrong Argument");
        if (!session.IsAvailable(id))
        {
            throw new ArgumentException("Id Exception");
        }

        Account? account = accountStorage.FindAccount(id);
        if (account == null) throw new ArgumentException("Account with this Id wasn't found");

        accountStorage.CreateTransaction(id, TypeOfTransaction.Deposit, _cashVerificator.Value);

        account.AddAmountOfCash(_cashVerificator);
        accountStorage.SaveAccount(account);
    }
}