namespace Itmo.ObjectOrientedProgramming.Lab1;

public static class HullValueObjects
{
    public static int Strength { get; private set; }

    public static void SetStrength(int value)
    {
        Strength = value;
    }

    public static void StrengthDecreaser(int damage)
    {
        Strength -= damage;
    }
}