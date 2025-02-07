using System;
namespace Itmo.ObjectOrientedProgramming.Lab1;

public class ShipValueObjects
{
    public double AmountOfFuel { get; private set; }
    public double Graviton { get; private set; }
    public bool IsCrewAlive { get; private set; } = true;
    public bool IsShipAlive { get; private set; } = true;
    public bool IsShipLost { get; private set; }

    public static void CatchNegativeValuesMoveInFog(int value1)
    {
        if (value1 < 0)
        {
            throw new InvalidOperationException("Length Can not be -Value");
        }
    }

    public static void CatchNegativeValuesMoveThroughtSpace(int value1, int value2, int value3)
    {
        if (value1 < 0 || value2 < 0 || value3 < 0)
        {
            throw new InvalidOperationException("Length Can not be -Value");
        }
    }

    public void FuelIncreaser(double value)
    {
        AmountOfFuel += value;
    }

    public void DieOfShip()
    {
        IsShipAlive = false;
    }

    public void DeathOfCrew()
    {
        IsCrewAlive = false;
    }

    public void LostInVoid()
    {
        IsShipLost = true;
    }
}