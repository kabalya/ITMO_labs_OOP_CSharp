using Xunit;
namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

  public static class Test
  {
      [Theory]
      [MemberData(nameof(TestData.Test1FileDisconnectData), MemberType = typeof(TestData))]
      public static void Test1FileDisconect(string textOfCommand)
      {
          // Arrange
          var parser = new Parser(textOfCommand);
          var fileSystemHandler = new FileSystemHandler(parser);

          // Act
          parser.Parse();
          fileSystemHandler.DefineCommand();

          // Assert
          Assert.True(fileSystemHandler.CommandFromHandler is Disconnect);
      }

      [Theory]
      [MemberData(nameof(TestData.Test2FileConnectData), MemberType = typeof(TestData))]
      public static void Test2FileConnect(string textOfCommand)
      {
          // Arrange
          var parser = new Parser(textOfCommand);
          var fileSystemHandler = new FileSystemHandler(parser);

          // Act
          parser.Parse();
          fileSystemHandler.DefineCommand();

          // Assert
          Assert.True(fileSystemHandler.CommandFromHandler is Connect);
      }

      [Theory]
      [MemberData(nameof(TestData.Test3FileCopyData), MemberType = typeof(TestData))]
      public static void Test3FileCopy(string textOfCommand)
      {
          // Arrange
          var parser = new Parser(textOfCommand);
          var fileSystemHandler = new FileSystemHandler(parser);

          // Act
          parser.Parse();
          fileSystemHandler.DefineCommand();

          // Assert
          Assert.True(fileSystemHandler.CommandFromHandler is FileCopy);
      }

      [Theory]
      [MemberData(nameof(TestData.Test4FileMoveData), MemberType = typeof(TestData))]
      public static void Test4FileMove(string textOfCommand)
      {
          // Arrange
          var parser = new Parser(textOfCommand);
          var fileSystemHandler = new FileSystemHandler(parser);

          // Act
          parser.Parse();
          fileSystemHandler.DefineCommand();

          // Assert
          Assert.True(fileSystemHandler.CommandFromHandler is FileMove);
      }

      [Theory]
      [MemberData(nameof(TestData.Test5FileDeleteData), MemberType = typeof(TestData))]
      public static void Test5FileDelete(string textOfCommand)
      {
          // Arrange
          var parser = new Parser(textOfCommand);
          var fileSystemHandler = new FileSystemHandler(parser);

          // Act
          parser.Parse();
          fileSystemHandler.DefineCommand();

          // Assert
          Assert.True(fileSystemHandler.CommandFromHandler is FileDelete);
      }

      [Theory]
      [MemberData(nameof(TestData.Test6FileRenameData), MemberType = typeof(TestData))]
      public static void Test6FileRename(string textOfCommand)
      {
          // Arrange
          var parser = new Parser(textOfCommand);
          var fileSystemHandler = new FileSystemHandler(parser);

          // Act
          parser.Parse();
          fileSystemHandler.DefineCommand();

          // Assert
          Assert.True(fileSystemHandler.CommandFromHandler is FileRename);
      }

      [Theory]
      [MemberData(nameof(TestData.Test7FileShowData), MemberType = typeof(TestData))]
      public static void Test7FileShow(string textOfCommand)
      {
          // Arrange
          var parser = new Parser(textOfCommand);
          var fileSystemHandler = new FileSystemHandler(parser);

          // Act
          parser.Parse();
          fileSystemHandler.DefineCommand();

          // Assert
          Assert.True(fileSystemHandler.CommandFromHandler is FileShow);
      }

      [Theory]
      [MemberData(nameof(TestData.Test8TreeGoToData), MemberType = typeof(TestData))]
      public static void Test8TreeGoTo(string textOfCommand)
      {
          // Arrange
          var parser = new Parser(textOfCommand);
          var fileSystemHandler = new FileSystemHandler(parser);

          // Act
          parser.Parse();
          fileSystemHandler.DefineCommand();

           // Assert
          Assert.True(fileSystemHandler.CommandFromHandler is TreeGoTo);
      }

      [Theory]
      [MemberData(nameof(TestData.Test9TreeListData), MemberType = typeof(TestData))]
      public static void Test9TreeList(string textOfCommand)
      {
          // Arrange
          var parser = new Parser(textOfCommand);
          var fileSystemHandler = new FileSystemHandler(parser);

          // Act
          parser.Parse();
          fileSystemHandler.DefineCommand();

          // Assert
          Assert.True(fileSystemHandler.CommandFromHandler is TreeList);
      }
}