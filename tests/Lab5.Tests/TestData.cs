using System.Collections.Generic;
using BankProject;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public static class TestData
{
    public static IEnumerable<object[]> ParserTestData()
    {
        IAccountStorage accountStorage = new MockAccountStorage();
        Account account = accountStorage.CreateAccount("password", "name");

        ISession adminSession = new AdminAvailability();
        ISession clientSession = new AccountAvailability(account);

        ComandParser adminCommandParser = ConsoleUser.CreateAdminParser();
        ComandParser clientCommandParser = ConsoleUser.CreateUserParser(account);

        yield return new object[]
        {
            clientSession, clientCommandParser, "deposit 1000",
            new DoDeposit(account.Id, new CashVerificator(1000)),
        };
        yield return new object[]
        {
            clientSession, clientCommandParser, "withdraw 1000",
            new Withdraw(account.Id, new CashVerificator(1000)),
        };
        yield return new object[]
        {
            clientSession, clientCommandParser, "balance",
            new InfoComandPrint(account.Id, new MockUserInformation()),
        };

        yield return new object[]
        {
            adminSession, adminCommandParser, "deposit 2 200", new DoDeposit(2, new CashVerificator(200)),
        };
        yield return new object[]
        {
            adminSession, adminCommandParser, "withdraw 2 200", new Withdraw(2, new CashVerificator(200)),
        };
        yield return new object[]
        {
            adminSession, adminCommandParser, "balance 2",
            new InfoComandPrint(2, new MockUserInformation()),
        };
    }

    public static IEnumerable<object[]> DoSomethingData()
    {
        IAccountStorage accountStorage = new MockAccountStorage();

        yield return new object[] { accountStorage };
    }
}