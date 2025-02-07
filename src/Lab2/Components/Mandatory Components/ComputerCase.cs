using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ComputerCase
{
    private ValueObjects _valueObjects = new ValueObjects();

    public ComputerCase(int maxLengthofVideoCard, int maxWidthofVideoCard, int powerConsumption, IReadOnlyCollection<string> formFactorOfMotherPlate, int size)
    {
        MaxLengthofVideoCard = maxLengthofVideoCard;
        _valueObjects.AddCheckMinusValue(maxLengthofVideoCard);
        MaxWidthofVideoCard = maxWidthofVideoCard;
        _valueObjects.AddCheckMinusValue(maxWidthofVideoCard);
        PowerConsumption = powerConsumption;
        _valueObjects.AddCheckMinusValue(powerConsumption);
        ListFormFactorOfMotherPlate = formFactorOfMotherPlate;
        Size = size;
        _valueObjects.AddCheckMinusValue(size);
    }

    public int MaxLengthofVideoCard { get; }
    public int MaxWidthofVideoCard { get; }
    public int PowerConsumption { get; }
    public IReadOnlyCollection<string> ListFormFactorOfMotherPlate { get; }
    public int Size { get; }
}