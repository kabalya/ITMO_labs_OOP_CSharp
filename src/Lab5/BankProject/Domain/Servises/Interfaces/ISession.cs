namespace BankProject;

public interface ISession
{
    public bool IsAvailable(long id);
}