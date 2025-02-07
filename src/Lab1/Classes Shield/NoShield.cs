namespace Itmo.ObjectOrientedProgramming.Lab1;

internal class NoShield : ShieldA
{
    public NoShield()
    {
        ShieldValueObject?.SetHp(0);
        ShipVO = new ShipValueObjects();
        ShieldValueObject = new ShieldValueObjects();
    }

    public ShipValueObjects ShipVO { get; }
    public new ShieldValueObjects ShieldValueObject { get; }
}