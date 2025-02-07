using BankProject;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class MockUserInformation : IUserInformation
{
    public int Count { get; private set; }

    public void Print(Account account)
    {
        Count++;
    }
}