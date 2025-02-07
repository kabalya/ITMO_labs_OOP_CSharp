namespace BankProject;

public interface IUserComand
{
    public void Execute(ISession session, IAccountStorage accountStorage);
}