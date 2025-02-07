using System.Globalization;

namespace BankProject;

public class AdministratorCashWithdraw : IUserComands
{
    public IUserComand Create(ParsedComand parsedComand)
    {
        if (parsedComand is null) throw new ArgumentException("Wrong Agument");

        string parsedId = parsedComand.GetArgument(0);
        long administratorId = Convert.ToInt64(parsedId, CultureInfo.InvariantCulture);

        ParsedComand subcommand = parsedComand.GetSubcommand();
        return new WithdrawUserComand(administratorId).Create(subcommand);
    }
}