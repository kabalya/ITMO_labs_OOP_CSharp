namespace Itmo.ObjectOrientedProgramming.Lab2;

public class WiFiAdapter
{
    private ValueObjects _valueObjects = new ValueObjects();
    public WiFiAdapter(string versionOfStandart, bool isBluetoothIncluded, string pciVersion, int powerConsumption)
    {
        VersionOfStandart = versionOfStandart;
        IsBluetoothIncluded = isBluetoothIncluded;
        PCIversion = pciVersion;
        PowerConsumption = powerConsumption;
        _valueObjects.AddCheckMinusValue(powerConsumption);
    }

    public string VersionOfStandart { get; }
    public bool IsBluetoothIncluded { get; }
    public string PCIversion { get; }
    public int PowerConsumption { get; }
}