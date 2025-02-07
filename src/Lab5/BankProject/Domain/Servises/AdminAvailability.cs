namespace BankProject;

public class AdminAvailability : ISession
{
    public bool IsAvailable(long id)
    {
        return true;
    }
}