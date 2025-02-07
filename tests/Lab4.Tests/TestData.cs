using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;
public static class TestData
{
    public static IEnumerable<object[]> Test1FileDisconnectData()
    {
        yield return new object[]
        {
            @"disconnect",
        };
    }

    public static IEnumerable<object[]> Test2FileConnectData()
    {
        yield return new object[]
        {
            @"connect C:\Users\User\Desktop\ZZZ -m local",
        };
    }

    public static IEnumerable<object[]> Test3FileCopyData()
    {
        yield return new object[]
        {
            @"file copy C:\Users\User\Desktop\ZZZ\OdetoJoy.txt C:\Users\User\Desktop\OdetoJoy.txt",
        };
    }

    public static IEnumerable<object[]> Test4FileMoveData()
    {
        yield return new object[]
        {
            @"file move C:\Users\User\Desktop\ZZZ\USSRanthem.txt C:\Users\User\Desktop\LyricsOfGreatestSongs\USSRanthem.txt",
        };
    }

    public static IEnumerable<object[]> Test5FileDeleteData()
    {
        yield return new object[]
        {
            @"file delete C:\Users\User\Desktop\ZZZ\USA.txt",
        };
    }

    public static IEnumerable<object[]> Test6FileRenameData()
    {
        yield return new object[]
        {
            @"file rename C:\Users\User\Desktop\ZZZ\MyDreams MyReality ",
        };
    }

    public static IEnumerable<object[]> Test7FileShowData()
    {
        yield return new object[]
        {
            @"file show C:\Users\User\Desktop\ZZZ\KGBAgentNumberOneAntonZhabotinskyiDossier.txt -m console",
        };
    }

    public static IEnumerable<object[]> Test8TreeGoToData()
    {
        yield return new object[]
        {
            @"tree goto C:\Users\User\Desktop\AO\MMM.txt",
        };
    }

    public static IEnumerable<object[]> Test9TreeListData()
    {
        yield return new object[]
        {
             @"tree list -d 3",
        };
    }
}