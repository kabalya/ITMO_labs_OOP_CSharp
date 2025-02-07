namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class ShieldA
{
    public ShipValueObjects ShipValueObject { get; } = new ShipValueObjects();
    public ShieldValueObjects ShieldValueObject { get; } = new ShieldValueObjects();

    public virtual void TakeDamagePhotonShield(int numberOfPhotonWays, bool photonShield, ShipA ship)
        {
            if (!photonShield)
            {
                ShipValueObject.DeathOfCrew();
                return;
            }

            if (numberOfPhotonWays > 3)
            {
                 ShipValueObject.DeathOfCrew();
                 return;
            }
            else if (numberOfPhotonWays < 3)
            {
                ShieldValueObject.PhotonShieldHealthPointsDecreaser(numberOfPhotonWays);
                if (ShieldValueObject.PhotonShieldHealthPoints <= 0)
                {
                    ShipValueObject.DeathOfCrew();
                    return;
                }
            }

            ShieldValueObject.PhotonShieldHealthPointsNullifier();
        }
}
