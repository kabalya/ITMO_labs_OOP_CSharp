namespace Itmo.ObjectOrientedProgramming.Lab1;
    internal class SmallShield : ShieldA
    {
        public SmallShield(bool inputPhotonShield)
        {
            ShieldValueObject?.SetPhotonShield(inputPhotonShield);
            ShieldValueObject?.SetPhotonShieldHealthPoints(3);
            ShieldValueObject?.SetHp(100);
            ShipVO = new ShipValueObjects();
            ShieldValueObject = new ShieldValueObjects();
        }

        public new ShieldValueObjects ShieldValueObject { get; }
        public ShipValueObjects ShipVO { get; }
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

            if (numberOfPhotonWays < 3)
            {
                if (ShieldValueObject.PhotonShieldHealthPoints <= -1)
                {
                    ShipVO.DeathOfCrew();
                    return;
                }
            }

            ShieldValueObject.PhotonShieldHealthPointsNullifier();
        }
    }
