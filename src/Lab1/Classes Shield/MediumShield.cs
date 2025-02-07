namespace Itmo.ObjectOrientedProgramming.Lab1;

internal class MediumShield : ShieldA
{
    public MediumShield(bool inputPhotonShield)
    {
        ShieldValueObject?.SetPhotonShield(inputPhotonShield);
        ShieldValueObject?.SetPhotonShieldHealthPoints(3);
        ShieldValueObject?.SetHp(500);
        ShipVO = new ShipValueObjects();
        ShieldValueObject = new ShieldValueObjects();
    }

    public ShipValueObjects ShipVO { get; }
    public new ShieldValueObjects ShieldValueObject { get; }
    public override void TakeDamagePhotonShield(int numberOfPhotonWays, bool photonShield, ShipA ship)
    {
        if (!photonShield)
        {
            ShipVO.DeathOfCrew();
            return;
        }

        if (numberOfPhotonWays > 3)
        {
                ShipVO.DeathOfCrew();
                return;
        }
        else if (numberOfPhotonWays < 3)
        {
            ShieldValueObject.PhotonShieldHealthPointsDecreaser(numberOfPhotonWays);
            if (ShieldValueObject.PhotonShieldHealthPoints <= -1)
            {
                ShipVO.DeathOfCrew();
                return;
            }
        }

        ShieldValueObject.PhotonShieldHealthPointsNullifier();
    }
}