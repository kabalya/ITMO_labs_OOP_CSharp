using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Ram
{
    private ValueObjects _valueObjects = new ValueObjects();
    public Ram(int amountOfAvailableMemorySize, IReadOnlyList<string> supportedJEDECFrequency, string availableXmpdoсPprofile, string formFactor, string ddrStandardVersion, int powerConsumption)
    {
        AmountOfAvailableMemorySize = amountOfAvailableMemorySize;
        _valueObjects.AddCheckMinusValue(amountOfAvailableMemorySize);
        SupportedJEDECFrequency = supportedJEDECFrequency;
        AvailableXMPDOСProfile = availableXmpdoсPprofile;
        FormFactor = formFactor;
        DDRstandardVersion = ddrStandardVersion;
        PowerConsumption = powerConsumption;
        _valueObjects.AddCheckMinusValue(powerConsumption);
    }

    public int AmountOfAvailableMemorySize { get; }
    public IReadOnlyList<string> SupportedJEDECFrequency { get; }
    public string AvailableXMPDOСProfile { get; }
    public string FormFactor { get; }
    public string DDRstandardVersion { get; }
    public int PowerConsumption { get; }
}