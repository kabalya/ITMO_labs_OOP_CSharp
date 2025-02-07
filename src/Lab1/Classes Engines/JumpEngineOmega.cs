using System;
namespace Itmo.ObjectOrientedProgramming.Lab1;

public class JumpEngineOmega : JumpEngineA, IJumpEngine
{
    public JumpEngineOmega(int inputlengthOfJump)
    {
        JumpEngineValueObjects.CatchMistakesOfLength(inputlengthOfJump);
        JumpEngineValueObject?.SetLength(inputlengthOfJump);
        ShipValueObject = new ShipValueObjects();
        JumpEngineValueObject = new JumpEngineValueObjects();
    }

    public ShipValueObjects ShipValueObject { get; }
    public JumpEngineValueObjects JumpEngineValueObject { get; }
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
        else if (lengthOfJump > 2)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}