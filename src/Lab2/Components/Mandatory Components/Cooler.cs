using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Cooler
{
    private ValueObjects _valueObjects = new ValueObjects();
    public Cooler(int size, IReadOnlyList<string> supportedSockets, int maximumHeatDissipation)
    {
        Size = size;
        _valueObjects.AddCheckMinusValue(size);
        SupportedSockets = supportedSockets;
        MaximumHeatDissipation = maximumHeatDissipation;
        _valueObjects.AddCheckMinusValue(maximumHeatDissipation);
    }

    public int Size { get; }
    public IReadOnlyList<string> SupportedSockets { get; }
    public int MaximumHeatDissipation { get; }
}