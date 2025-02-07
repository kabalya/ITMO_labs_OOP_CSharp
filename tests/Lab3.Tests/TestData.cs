using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public static class TestData
{
    public static IEnumerable<object[]> Test1MessageInputedButNotReadYetData()
    {
        yield return new object[]
        {
            40, "Hello,My Lover", "I wanna to say you that I am straight man, so Filip...we have to broke up...",
        };
    }

    public static IEnumerable<object[]> Test2MessageInputedAndAlreadyReadData()
    {
        yield return new object[]
        {
            40, "Hey,Jesus", "Today I saw a fat monkey eating a Barak Obama, a Nazi Hamburger ran up to monkey and ate Obama ",
        };
    }

    public static IEnumerable<object[]> Test3MessageInputedButImportanceLevelIsLowerThanFilterData()
    {
        yield return new object[]
        {
            100, "Anthem of my MotherLand",
            "United Forever in Friendship and Labour,Our mighty Republics will ever endure.The Great Soviet Union will Live through the Ages.The Dream of a People their fortress secure.Long Live our Soviet Motherland,Built by the People's mighty hand.Long Live our People, United and Free.Strong in our Friendship tried by fire.Long may our Crimson Flag Inspire,Shining in Glory for all Men to see.",
        };
    }

    public static IEnumerable<object[]> Test4MessageIsInputedIntoAddresatFromTopicSuccesfullyData()
    {
        yield return new object[]
        {
            40, "Speach of Winston",
            "We shall go on to the end. We shall fight in France, we shall fight on the seas and oceans, we shall fight with growing confidence and growing strength in the air, we shall defend our island, whatever the cost may be. We shall fight on the beaches, we shall fight on the landing grounds, we shall fight in the fields and in the streets, we shall fight in the hills; we shall never surrender, and if, which I do not for a moment believe, this island or a large part of it were subjugated and starving, then our Empire beyond the seas, armed and guarded by the British Fleet, would carry on the struggle, until, in God’s good time, the New World, with all its power and might, steps forth to the rescue and the liberation of the old. ",
        };
    }

    public static IEnumerable<object[]> Test5MessangerWorkedCorrectlyData()
    {
        yield return new object[]
        {
            40, "To British Government", "Today, germans damadged Royal Oak and entered Scapo Flou",
        };
    }
}