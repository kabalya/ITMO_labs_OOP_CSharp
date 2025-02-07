using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Cpu
{
    private ValueObjects _valueObjects = new ValueObjects();
    public Cpu(string name, int frequenciesOfCores, int amountOfCores, string socketOfCpu, bool hasGraphicCore, IReadOnlyList<string> supportedFrequencies, int heatProduction, int powerConsumption)
    {
        Name = name;
        FrequenciesOfCores = frequenciesOfCores;
        AmountOfCores = amountOfCores;
        _valueObjects.AddCheckMinusValue(amountOfCores);
        SocketCpu = socketOfCpu;
        HasGraphicCore = hasGraphicCore;
        SupportedFrequencies = supportedFrequencies;
        HeatProduction = heatProduction;
        _valueObjects.AddCheckMinusValue(heatProduction);
        PowerConsumption = powerConsumption;
        _valueObjects.AddCheckMinusValue(powerConsumption);
    }

    public string Name { get; }
    public int FrequenciesOfCores { get; }
    public int AmountOfCores { get; }
    public string SocketCpu { get; }
    public bool HasGraphicCore { get; }
    public IReadOnlyList<string> SupportedFrequencies { get; }

    public int HeatProduction { get; }
    public int PowerConsumption { get; }
}