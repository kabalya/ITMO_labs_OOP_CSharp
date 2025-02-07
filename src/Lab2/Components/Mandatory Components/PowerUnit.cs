namespace Itmo.ObjectOrientedProgramming.Lab2;

public class PowerUnit
{
   private ValueObjects _valueObjects = new ValueObjects();
   public PowerUnit(int maxProductingOfEnergy)
   {
      MaxProductingOfEnergy = maxProductingOfEnergy;
      _valueObjects.AddCheckMinusValue(maxProductingOfEnergy);
   }

   public int MaxProductingOfEnergy { get; }
}