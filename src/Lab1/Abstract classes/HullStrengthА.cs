namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class HullStrengthА
{
    public virtual void TakeDamage(int damage)
    {
        HullValueObjects.StrengthDecreaser(damage);
    }
}