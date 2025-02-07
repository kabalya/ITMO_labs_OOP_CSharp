namespace Itmo.ObjectOrientedProgramming.Lab2;

public class XmpProfile
{
    private ValueObjects _valueObjects = new ValueObjects();
    public XmpProfile(string timing, int voltage, int frequency)
    {
        Timing = timing;
        Voltage = voltage;
        _valueObjects.AddCheckMinusValue(voltage);
        Frequency = frequency;
        _valueObjects.AddCheckMinusValue(frequency);
    }

    public string Timing { get; }
    public int Voltage { get; }
    public int Frequency { get; }
}
