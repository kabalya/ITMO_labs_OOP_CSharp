using System;
using BankProject;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class ComandTest
{
    [Theory]
    [MemberData(nameof(TestData.ParserTestData), MemberType = typeof(TestData))]
    public void ParserTest(ISession session, ComandParser comandParser, string input, IUserComand comand)
    {
        if (session is null) throw new ArgumentException("Wrong Argument");
        if (comandParser is null) throw new ArgumentException("Wrong Argument");
        IUserComand parsedComand = comandParser.Parse(input);
        Assert.Equivalent(comand, parsedComand);
    }

    [Theory]
    [MemberData(nameof(TestData.DoSomethingData), MemberType = typeof(TestData))]
    public void DoDepositTest(IAccountStorage accountStorage)
    {
        // Arrange
        if (accountStorage is null) throw new ArgumentException("Wrong Argument");
        ISession session = new AdminAvailability();
        Account account = accountStorage.CreateAccount("password", "name");
        var dodepos = new DoDeposit(account.Id, new CashVerificator(100));

        // Act
        dodepos.Execute(session, accountStorage);
        Account? user = accountStorage.FindAccount(account.Id);

        // Assert
        Assert.NotNull(user);
        Assert.Equal(account.Balance + 100, user.Balance);
    }

    [Theory]
    [MemberData(nameof(TestData.DoSomethingData), MemberType = typeof(TestData))]
    public void WithdrawTest(IAccountStorage accountStorage)
    {
        // Arrange
        if (accountStorage is null) throw new ArgumentException("Wrong Argument");
        ISession session = new AdminAvailability();
        Account account = accountStorage.CreateAccount("password", "name");
        var dodepos = new DoDeposit(account.Id, new CashVerificator(100));
        var withdraw = new Withdraw(account.Id, new CashVerificator(50));

        // Act
        dodepos.Execute(session, accountStorage);
        withdraw.Execute(session, accountStorage);
        Account? user = accountStorage.FindAccount(account.Id);

        // Assert
        Assert.NotNull(user);
        Assert.Equal(account.Balance + 50, user.Balance);
    }

    [Theory]
    [MemberData(nameof(TestData.DoSomethingData), MemberType = typeof(TestData))]
    public void MockTest(IAccountStorage accountStorage)
    {
        // Arrange
        if (accountStorage is null) throw new ArgumentException("Wrong Argument");
        ISession session = new AdminAvailability();
        Account account = accountStorage.CreateAccount("password", "name");
        Account? user = accountStorage.FindAccount(account.Id);
        var printer = new MockUserInformation();
        var infoComandPrint = new InfoComandPrint(account.Id, printer);

        // Act
        infoComandPrint.Execute(session, accountStorage);

        // Assert
        Assert.NotNull(user);
        Assert.NotEqual(4, printer.Count);
        Assert.Equal(1, printer.Count);
    }
}