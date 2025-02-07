namespace Itmo.ObjectOrientedProgramming.Lab1;

public class ShieldValueObjects
{
    public bool IsNitrinRadiatorActivated { get; private set; }
    public int Hp { get; private set; }
    public bool PhotonShield { get; private set; }
    public int RemainingDamage { get; private set; }
    public int PhotonShieldHealthPoints { get; private set; }
    public int DamageOfSmallAsteroid { get; private set; } = 50;
    public int DamageOfBigMeteorites { get; private set; } = 200;
    public int DamageOfNumberOfWhales { get; private set; } = 2000;
    public void PhotonShieldHealthPointsDecreaser(int numberOfPhotonWays)
    {
        PhotonShieldHealthPoints -= numberOfPhotonWays;
    }

    public void PhotonShieldHealthPointsNullifier()
    {
        PhotonShieldHealthPoints = 0;
    }

    public void TakeDamage(int damage)
    {
        if (damage >= Hp)
        {
            RemainingDamage = damage - Hp;
            Hp = 0;
        }
        else
        {
            Hp -= damage;
        }
    }

    public int CalculateTotalDamage(int numberOfSmallMeteorites, int numberOfBigMeteorites, int inputNumberOfWhales)
    {
        int totalDamage = (numberOfSmallMeteorites * DamageOfSmallAsteroid) + (numberOfBigMeteorites * DamageOfBigMeteorites) + (inputNumberOfWhales * DamageOfNumberOfWhales);
        return totalDamage;
    }

    public void SetHp(int value)
    {
        Hp = value;
    }

    public void SetPhotonShield(bool value)
    {
        PhotonShield = value;
    }

    public void SetPhotonShieldHealthPoints(int value)
    {
        PhotonShieldHealthPoints = value;
    }
}