namespace BankProject;

public class Account
{
    public Account(long id, string password, string name, long balance)
    {
        ArgumentNullException.ThrowIfNull(password);

        Id = id;
        Password = password;
        Name = name;
        Balance = balance;
    }

    public long Id { get; init; }
    public string Name { get; init; }
    public string Password { get; init; }
    public long Balance { get; private set; }

    public void AddAmountOfCash(CashVerificator cashVerificator)
    {
        if (cashVerificator is null) throw new ArgumentException(" Wrong Argument");
        Balance += cashVerificator.Value;
    }

    public void DecreaseMoney(CashVerificator cashVerificator)
    {
        if (cashVerificator is null) throw new ArgumentException(" Wrong Argument");
        if (Balance < cashVerificator.Value)
        {
            throw new ArgumentException("Account have less money than is needed");
        }

        Balance -= cashVerificator.Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is Account account && account.Id == Id && account.Password.Equals(Password, StringComparison.Ordinal) && account.Name.Equals(Name, StringComparison.Ordinal) && account.Balance == Balance;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Password, Name, Balance);
    }
}