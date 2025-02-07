namespace BankProject;

public class UserComandErrorsCatcher : IUserComand
{
    private readonly IUserComand userComand;

    public UserComandErrorsCatcher(IUserComand userComand)
    {
        this.userComand = userComand;
    }

    public void Execute(ISession session, IAccountStorage accountStorage)
    {
        try
        {
            userComand.Execute(session, accountStorage);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}