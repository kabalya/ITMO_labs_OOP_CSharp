using System.Globalization;

namespace BankProject;

public class WithdrawUserComand : IUserComands
{
    private readonly long id;

    public WithdrawUserComand(long id)
    {
        this.id = id;
    }

    public IUserComand Create(ParsedComand parsedComand)
    {
        if (parsedComand is null) throw new ArgumentException("Wrong Agument");

        string parsedAmount = parsedComand.GetArgument(0);
        long amountOfCash = Convert.ToInt64(parsedAmount, CultureInfo.InvariantCulture);
        return new Withdraw(id, new CashVerificator(amountOfCash));
    }
}