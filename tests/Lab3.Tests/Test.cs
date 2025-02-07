using NSubstitute;
using Xunit;
namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public static class Test
{
    [Theory]
    [MemberData(nameof(TestData.Test1MessageInputedButNotReadYetData), MemberType = typeof(TestData))]
    public static void Test1MessageInputedButNotReadYet(int importanceLevel, string title, string body)
    {
        // Arrange
        var message = new Message(title, body, 99, false, 2);
        var user = new User();
        var addresat = new AddresatUser(importanceLevel, user);
        var topic = new Topic("topicTest1", addresat);

        // Act
        topic.InputMessage(message);

        // Assert
        Assert.True(user.IsMessageNotReadYet(message));
    }

    [Theory]
    [MemberData(nameof(TestData.Test2MessageInputedAndAlreadyReadData), MemberType = typeof(TestData))]
    public static void Test2MessageInputedAndAlreadyRead(int importanceLevel, string title, string body)
    {
        // Arrange
        var message = new Message(title, body, 99, false, 1);
        var user = new User();
        var addresat = new AddresatUser(importanceLevel, user);
        var topic = new Topic("topicTest2", addresat);

        // Act
        topic.InputMessage(message);
        user.MarkAsRead(message);

        // Assert
        Assert.False(user.IsMessageNotReadYet(message));
    }

    [Theory]
    [MemberData(nameof(TestData.Test3MessageInputedButImportanceLevelIsLowerThanFilterData), MemberType = typeof(TestData))]
    public static void Test3MessageInputedButImportanceLevelIsLowerThanFilter(int importanceLevel, string title, string body)
    {
        // Arrange
        User user = Substitute.For<User>();
        var addresat = new AddresatUser(importanceLevel, user);
        var topic = new Topic("TestTopic", addresat);
        var message = new Message(title, body, 60, false, 5);

        // Act
        topic.InputMessage(message);

        // Assert
        user.Received(1).InputMessage(message);
    }

    [Theory]
    [MemberData(nameof(TestData.Test4MessageIsInputedIntoAddresatFromTopicSuccesfullyData), MemberType = typeof(TestData))]
    public static void Test4MessageIsInputedIntoAddresatFromTopicSuccesfully(int importanceLevel, string title, string body)
    {
        // Arrange
        var message = new Message(title, body, 99, false, 10);
        var user = new User();
        var addresat = new AddresatUser(importanceLevel, user);
        var topic = new Topic("topicOfGovernment", addresat);

        // Act
        topic.InputMessage(message);
        user.MarkAsRead(message);

        // Assert
        Assert.False(user.IsMessageNotReadYet(message));
    }

    [Theory]
    [MemberData(nameof(TestData.Test5MessangerWorkedCorrectlyData), MemberType = typeof(TestData))]
    public static void Test5MessangerWorkedCorrectly(int importanceLevel, string title, string body)
    {
        // Arrange
        var message = new Message(title, body, 99, false, 13);
        var printer = new ConsolePrinter();
        var messanger = new Messanger(printer);
        var addresat = new AddresatMessanger(importanceLevel, messanger);
        var topic = new Topic("topicEnglishKingCrying", addresat);

        // Act
        topic.InputMessage(message);

        // Assert
        Assert.True(messanger.IsExpectingValue);
    }
}
