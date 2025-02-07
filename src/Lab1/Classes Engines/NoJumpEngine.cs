using System;
namespace Itmo.ObjectOrientedProgramming.Lab1;

public class NoJumpEngine : JumpEngineA
{
    public NoJumpEngine()
    {
        ShipValueObject = new ShipValueObjects();
    }

    public ShipValueObjects ShipValueObject { get; }
    public void JumpOfJumpEngine(bool value)
    {
        var fuelCollector = new FuelCollectorClass();
        if (value)
        {
            ShipValueObject.FuelIncreaser(fuelCollector.EngineJumpAlphaFlow);
        }
        else
        {
            ShipValueObject.LostInVoid();
        }
    }

    public override bool CanJump(int lengthOfJump)
    {
        if (lengthOfJump < 0)
        {
            throw new InvalidOperationException("Length Can not be -Value");
        }
        else if (lengthOfJump > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}