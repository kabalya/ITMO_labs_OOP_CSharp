using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2;
public class MotherBoard
{
    private ValueObjects _valueObjects = new ValueObjects();
    public MotherBoard(string socketOfCpu, int numberOfPcieLines, int numberOfSataPorts, IReadOnlyList<string> memoryfrequencies, bool isSupportingXmp, string supportedDDRStandart, int numberOfDDRSlots, string formFactor, string biosType, string biosVersion)
    {
        SocketCpu = socketOfCpu;
        NumberOfPcieLines = numberOfPcieLines;
        _valueObjects.AddCheckMinusValue(numberOfPcieLines);
        NumberOfSataPorts = numberOfSataPorts;
        _valueObjects.AddCheckMinusValue(numberOfSataPorts);
        SupportedDDRStandart = supportedDDRStandart;
        NumberOfDDRSlots = numberOfDDRSlots;
        _valueObjects.AddCheckMinusValue(numberOfDDRSlots);
        FormFactor = formFactor;
        BiosType = biosType;
        BiosVersion = biosVersion;
        SupportedFrequencies = memoryfrequencies;
        IsSupportingXmp = isSupportingXmp;
    }

    public string SocketCpu { get; }
    public int NumberOfPcieLines { get; }
    public int NumberOfSataPorts { get; }
    public IReadOnlyList<string> SupportedFrequencies { get; }
    public bool IsSupportingXmp { get; }
    public string SupportedDDRStandart { get; }
    public int NumberOfDDRSlots { get; protected set; }
    public string FormFactor { get; }
    public string BiosType { get; }
    public string BiosVersion { get; }

    public void DecreaserOfDdrSlots()
    {
        NumberOfDDRSlots -= 1;
    }
}