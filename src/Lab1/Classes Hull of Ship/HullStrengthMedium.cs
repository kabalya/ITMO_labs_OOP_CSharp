namespace Itmo.ObjectOrientedProgramming.Lab1;

internal class HullStrengthMedium : HullStrengthА
{
    public static void SetStrength()
    {
        int value1 = 250;
        HullValueObjects.SetStrength(value1);
    }

    public override void TakeDamage(int damage)
    {
        HullValueObjects.StrengthDecreaser(damage);
    }
}