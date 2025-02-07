namespace Itmo.ObjectOrientedProgramming.Lab1;

internal class HullStrengthLarge : HullStrengthА
{
    public static void SetStrength()
    {
        int value1 = 1000;
        HullValueObjects.SetStrength(value1);
    }

    public override void TakeDamage(int remainingDamage)
    {
        HullValueObjects.StrengthDecreaser(remainingDamage);
    }
}