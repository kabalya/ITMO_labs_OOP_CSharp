using System;
namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class ShipA
{
    private ShipValueObjects _shipValueObjects = new ShipValueObjects();
    public ShieldValueObjects ShieldValueObject { get; protected set; } = new ShieldValueObjects();

    public virtual void MoveInNitrinFog(bool isNitrinFog, int numberOfPhotonWays, bool photonShield, ShieldA shield, FuelCollectorClass fuelCollector)
    {
            if (shield != null && isNitrinFog && ShieldValueObject.Hp <= 0)
            {
                _shipValueObjects.DeathOfCrew();
            }
            else if (shield != null && isNitrinFog && ShieldValueObject.Hp > 0)
            {
                shield.TakeDamagePhotonShield(numberOfPhotonWays, photonShield, this);
            }
    }

    public virtual void MoveThroughSpace(int numberOfSmallMeteorites, int numberOfBigMeteorites, int inputNumberOfWhales)
    {
        int numberOfWhalesDamage = inputNumberOfWhales;
        if (ShieldValueObject.IsNitrinRadiatorActivated)
        {
            numberOfWhalesDamage = 0;
        }

        int totalDamage = (numberOfSmallMeteorites * 50) + (numberOfBigMeteorites * 200) + (numberOfWhalesDamage * 2000);
        if (totalDamage < 0)
        {
            throw new InvalidOperationException("Length Can not be -Value");
        }
        else if (totalDamage > 3000)
        {
            _shipValueObjects.DieOfShip();
        }
    }
}