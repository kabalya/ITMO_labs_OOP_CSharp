using System.Collections.Generic;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class TestClass
{
    public static IEnumerable<object[]> Test1PleasureShutleLostInVoidData()
    {
        yield return new object[]
        {
            1, 1, 6,
        };
        yield return new object[]
        {
            1, 1, 5,
        };
    }

    [Theory]
    [MemberData(nameof(Test1PleasureShutleLostInVoidData))]
    public static void Test1PleasureShutleLostInVoid(int inputNumberofSmallMeteorites, int inputNumberofBigMeteorites, int inputnumberOfWhales)
    {
        // Arrange
        var ship = new PleasureShuttle();
        var jumpEngine = new NoJumpEngine();

        // Act
        ship.MoveInNitrinFog(false, 0, true);
        jumpEngine.JumpOfJumpEngine(jumpEngine.CanJump(1));
        ship.MoveThroughSpace(inputNumberofSmallMeteorites, inputNumberofBigMeteorites, inputnumberOfWhales);

        // Assert
        Assert.True(jumpEngine.ShipValueObject.IsShipLost);
    }

    public static IEnumerable<object[]> Test1AvgoorLostInVoidData()
    {
        yield return new object[]
        {
            true, true, 6,
        };
        yield return new object[]
        {
            false, true, 5,
        };
    }

    [Theory]
    [MemberData(nameof(Test1AvgoorLostInVoidData))]
    public static void Test1AvgoorLostInVoid(bool isPhotonShieldEnable, bool isNitrinRadiatorEnable, int inputlengthOfJump)
    {
        // Arrange
        var ship = new Avgoor(isPhotonShieldEnable, isNitrinRadiatorEnable, inputlengthOfJump);
        var jumpEngine = new JumpEngineAlpha(inputlengthOfJump);

        // Act
        ship.MoveInNitrinFog(false, 0, isPhotonShieldEnable);
        jumpEngine.JumpOfJumpEngine(jumpEngine.CanJump(inputlengthOfJump));

        ship.MoveThroughSpace(0, 0, 0);
        Assert.False(ship.ShipValueObject.IsShipLost);
    }

    public static IEnumerable<object[]> Test2VaklasWithoutPhotonDeflectorDieOfCrewData()
    {
        yield return new object[]
        {
            false, false, 1,
        };
        yield return new object[]
        {
            false, false, 7,
        };
    }

    [Theory]
    [MemberData(nameof(Test2VaklasWithoutPhotonDeflectorDieOfCrewData))]
    public static void Test2VaklasWithoutPhotonDeflectorDieOfCrew(bool isPhotonShieldEnable, bool isNitrinRadiatorEnable, int inputLengthOfJump)
    {
        // Arrange
        var ship = new Vaklas(isPhotonShieldEnable, isNitrinRadiatorEnable, inputLengthOfJump);
        var jumpEngine = new JumpEngineAlpha(0);

        // Act
        ship.MoveInNitrinFog(true, 0, isPhotonShieldEnable);
        jumpEngine.JumpOfJumpEngine(jumpEngine.CanJump(inputLengthOfJump));
        ship.MoveThroughSpace(0, 0, 1);

        // Assert
        Assert.False(ship.ShipValueObject.IsCrewAlive);
    }

    public static IEnumerable<object[]> Test2VaklasWithPhotonDeflectorCrewIsAliveData()
    {
        yield return new object[]
        {
            true, false, 1,
        };
        yield return new object[]
        {
            true, false, 7,
        };
    }

    [Theory]
    [MemberData(nameof(Test2VaklasWithPhotonDeflectorCrewIsAliveData))]
    public static void Test2VaklasWithPhotonDeflectorCrewIsAlive(bool isPhotonShieldEnable, bool isNitrinRadiatorEnable, int inputLengthOfJump)
    {
        // Arrange
        var ship = new Vaklas(isPhotonShieldEnable, isNitrinRadiatorEnable, inputLengthOfJump);
        var jumpEngine = new JumpEngineAlpha(0);

        // Act
        ship.MoveInNitrinFog(true, 0, isPhotonShieldEnable);
        jumpEngine.JumpOfJumpEngine(jumpEngine.CanJump(inputLengthOfJump));
        ship.MoveThroughSpace(0, 0, 0);

        // Assert
        Assert.True(jumpEngine.ShipValueObject.IsCrewAlive);
    }

    public static IEnumerable<object[]> Test3VaklasDeathOfShipData()
    {
        yield return new object[]
        {
            true, false, 1,
        };
        yield return new object[]
        {
            true, false, 1,
        };
    }

    [Theory]
    [MemberData(nameof(Test3VaklasDeathOfShipData))]

    public static void Test3VaklasDeathOfShip(bool isPhotonShieldEnable, bool isNitrinRadiatorEnable, int inputLengthOfJump)
    {
        // Arrange
        var ship1 = new Vaklas(isPhotonShieldEnable, isNitrinRadiatorEnable, inputLengthOfJump);
        var jumpEngine = new JumpEngineAlpha(0);

        // Act
        ship1.MoveInNitrinFog(true, 1, isPhotonShieldEnable);
        jumpEngine.JumpOfJumpEngine(jumpEngine.CanJump(inputLengthOfJump));
        ship1.MoveThroughSpace(0, 4, 1);

        // Assert
        Assert.False(ship1.ShipValueObject.IsShipAlive);
    }

    public static IEnumerable<object[]> Test3AvgoorShipIsAliveData()
    {
        yield return new object[]
        {
            true, false, 2,
        };
        yield return new object[]
        {
            true, false, 2,
        };
    }

    [Theory]
    [MemberData(nameof(Test3AvgoorShipIsAliveData))]
    public static void Test3AvgoorShipIsAlive(bool isPhotonShieldEnable, bool isNitrinRadiatorEnable, int inputLengthOfJump)
    {
        // Arrange
        var ship2 = new Avgoor(isPhotonShieldEnable, isNitrinRadiatorEnable, inputLengthOfJump);
        var jumpEngine = new JumpEngineAlpha(inputLengthOfJump);

        // Act
        ship2.MoveInNitrinFog(true, 1, isPhotonShieldEnable);
        jumpEngine.JumpOfJumpEngine(jumpEngine.CanJump(inputLengthOfJump));
        ship2.MoveThroughSpace(0,    1, 0);

        // Assert
        Assert.True(ship2.ShipValueObject.IsShipAlive);
    }

    public static IEnumerable<object[]> Test3MeredianIsNotDeadData()
    {
        yield return new object[]
        {
            true, false,
        };
        yield return new object[]
        {
            true, false,
        };
    }

    [Theory]
    [MemberData(nameof(Test3MeredianIsNotDeadData))]
    public static void Test3MeredianIsNotDead(bool isPhotonShieldEnable, bool isNitrinRadiatorEnable)
    {
        // Arrange
        var ship3 = new Meredian(isPhotonShieldEnable, isNitrinRadiatorEnable);
        var jumpEngine = new JumpEngineAlpha(0);

        // Act
        ship3.MoveInNitrinFog(true, 0, isPhotonShieldEnable);
        jumpEngine.JumpOfJumpEngine(jumpEngine.CanJump(0));
        ship3.MoveThroughSpace(0, 0, 0);

        // Assert
        Assert.True(ship3.ShipValueObject.IsShipAlive);
    }

    public static IEnumerable<object[]> Test4PleasureShuttleAndVaklasCompareOfFuelData()
    {
        yield return new object[]
        {
            false,
        };
        yield return new object[]
        {
            false,
        };
    }

    [Theory]
    [MemberData(nameof(Test4PleasureShuttleAndVaklasCompareOfFuelData))]
    public static void Test4PleasureShuttleAndVaklasCompareOfFuel(bool isPhotonShieldEnable)
    {
        // Arrange
        var ship1 = new PleasureShuttle();
        var ship2 = new Vaklas(isPhotonShieldEnable, false, 1);
        var jumpEngine1 = new JumpEngineAlpha(0);
        var jumpEngine2 = new JumpEngineAlpha(0);

        // Act
        ship1.MoveInNitrinFog(false, 0, isPhotonShieldEnable);
        jumpEngine1.CanJump(0);
        ship1.MoveThroughSpace(2, 0, 0);
        ship2.MoveInNitrinFog(false, 0, isPhotonShieldEnable);
        jumpEngine2.JumpOfJumpEngine(jumpEngine2.CanJump(0));
        ship2.MoveThroughSpace(2, 1, 0);

        // Assert
        Assert.True(ship1.ShipValueObject.AmountOfFuel < ship2.ShipValueObject.AmountOfFuel);
    }

    public static IEnumerable<object[]> Test5AvgoorLostInTheVoidData()
    {
        yield return new object[]
        {
            true, true, 3,
        };
    }

    [Theory]
    [MemberData(nameof(Test5AvgoorLostInTheVoidData))]
    public static void Test5AvgoorLostInTheVoid(bool isPhotonShieldEnable, bool isNitrinRadiatorEnable, int inputLengthOfJump)
    {
        // Arrange
        var ship1 = new Avgoor(isPhotonShieldEnable, isNitrinRadiatorEnable, inputLengthOfJump);
        var jumpEngine1 = new JumpEngineAlpha(inputLengthOfJump);

        // Act
        ship1.MoveInNitrinFog(true, 0, isPhotonShieldEnable);
        jumpEngine1.JumpOfJumpEngine(jumpEngine1.CanJump(inputLengthOfJump));
        ship1.MoveThroughSpace(2, 2, 0);

        // Assert
        Assert.True(jumpEngine1.ShipValueObject.IsShipLost);
    }

    public static IEnumerable<object[]> Test5StellaNotLostData()
    {
        yield return new object[]
        {
            true, true, 0,
        };
    }

    [Theory]
    [MemberData(nameof(Test5StellaNotLostData))]
    public static void Test5StellaNotLost(bool isPhotonShieldEnable, bool isNitrinRadiatorEnable, int inputLengthOfJump)
    {
        // Arrange
        var ship2 = new Stella(isPhotonShieldEnable, isNitrinRadiatorEnable, inputLengthOfJump);
        var jumpEngine2 = new JumpEngineOmega(inputLengthOfJump);

        // Act
        ship2.MoveInNitrinFog(true, 0, isPhotonShieldEnable);
        jumpEngine2.JumpOfJumpEngine(jumpEngine2.CanJump(inputLengthOfJump));
        ship2.MoveThroughSpace(0, 0, 0);

        // Assert
        Assert.False(ship2.ShipValueObject.IsShipLost);
    }

    public static IEnumerable<object[]> TestPleasureShuttleDeathOfCrewData()
    {
        yield return new object[]
        {
            true, 0,
        };
    }

    [Theory]
    [MemberData(nameof(TestPleasureShuttleDeathOfCrewData))]
    public static void TestPleasureShuttleDeathOfCrew(bool isPhotonShieldEnable, int inputLengthOfJump)
    {
        // Arrange
        var ship1 = new PleasureShuttle();
        var jumpEngine1 = new JumpEngineAlpha(inputLengthOfJump);

        // Act
        ship1.MoveInNitrinFog(true, 5, isPhotonShieldEnable);
        jumpEngine1.CanJump(inputLengthOfJump);
        ship1.MoveThroughSpace(2, 0, 0);

        // Assert
        Assert.False(ship1.ShipValueObject.IsCrewAlive);
    }

    public static IEnumerable<object[]> Test6VaklasCrewIsAliveData()
    {
        yield return new object[]
        {
            true, false, 0,
        };
    }

    [Theory]
    [MemberData(nameof(Test6VaklasCrewIsAliveData))]
    public static void Test6VaklasCrewIsAlive(bool isPhotonShieldEnable, bool isNitrinRadiatorEnable, int inputLengthOfJump)
    {
        // Arrange
        var ship2 = new Vaklas(isPhotonShieldEnable, isNitrinRadiatorEnable, 0);
        var jumpEngine2 = new JumpEngineAlpha(inputLengthOfJump);

        // Act
        ship2.MoveInNitrinFog(false, 0, isPhotonShieldEnable);
        jumpEngine2.JumpOfJumpEngine(jumpEngine2.CanJump(inputLengthOfJump));
        ship2.MoveThroughSpace(2, 0, 0);

        // Assert
        Assert.True(ship2.ShipValueObject.IsCrewAlive);
    }

    public static IEnumerable<object[]> Test7MyOwnData()
    {
        yield return new object[]
        {
            true, false, 1,
        };
    }

    [Theory]
    [MemberData(nameof(Test7MyOwnData))]
    public void Test7MyOwn(bool isPhotonShieldEnable, bool isNitrinRadiatorEnable, int inputLengthOfJump)
    {
        // Arrange
        var ship1 = new PleasureShuttle();
        var ship2 = new Vaklas(isPhotonShieldEnable, isNitrinRadiatorEnable, inputLengthOfJump);
        var ship3 = new Vaklas(isPhotonShieldEnable, isNitrinRadiatorEnable, inputLengthOfJump);
        var jumpEngine1 = new JumpEngineAlpha(inputLengthOfJump);
        var jumpEngine2 = new JumpEngineAlpha(inputLengthOfJump);
        var jumpEngine3 = new JumpEngineAlpha(inputLengthOfJump);

          // Act
        ship1.MoveInNitrinFog(true, 5, isPhotonShieldEnable);
        jumpEngine1.CanJump(inputLengthOfJump);
        ship1.MoveThroughSpace(2,    8, 22);

        // Assert
        Assert.False(ship1.ShipValueObject.IsShipAlive);

          // Act
        ship2.MoveInNitrinFog(true, 5, isPhotonShieldEnable);
        jumpEngine2.JumpOfJumpEngine(jumpEngine2.CanJump(inputLengthOfJump));
        ship2.MoveThroughSpace(2,    0, 1);

        // Assert
        Assert.False(ship2.ShipValueObject.IsShipAlive);

          // Act
        ship3.MoveInNitrinFog(true, 7, isPhotonShieldEnable);
        jumpEngine3.JumpOfJumpEngine(jumpEngine3.CanJump(inputLengthOfJump));
        ship3.MoveThroughSpace(2,    55, 20);

        // Assert
        Assert.False(ship3.ShipValueObject.IsShipAlive);
    }
}