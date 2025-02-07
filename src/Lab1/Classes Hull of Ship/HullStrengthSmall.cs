namespace Itmo.ObjectOrientedProgramming.Lab1;

internal class HullStrengthSmall : HullStrengthА
{
    public static void SetStrength()
    {
        int value1 = 50;
        HullValueObjects.SetStrength(value1);
    }

    public override void TakeDamage(int remainingDamage)
    {
        HullValueObjects.StrengthDecreaser(remainingDamage);
    }
}