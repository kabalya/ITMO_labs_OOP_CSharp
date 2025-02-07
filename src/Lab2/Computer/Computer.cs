namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Computer : IComputer
{
    public Computer(ComputerCase case1, Cooler cooler, Cpu cpu1, MotherBoard motherBoard, PowerUnit powerUnit, Ram ram, Bios bios, WiFiAdapter wifiAdapter, XmpProfile xmpProfile, Hsd hsd, Ssd ssd, VideoCard videoCard)
    {
        ComputerCase = case1;
        Cooler = cooler;
        Cpu = cpu1;
        MotherBoard = motherBoard;
        PowerUnit = powerUnit;
        Ram = ram;
        Bios = bios;
        WifiAdapter = wifiAdapter;
        XmpProfile = xmpProfile;
        Hsd = hsd;
        Ssd = ssd;
        VideoCard = videoCard;
    }

    public ComputerCase ComputerCase { get; }
    public Cooler Cooler { get; }
    public Cpu Cpu { get; }
    public MotherBoard MotherBoard { get; }
    public PowerUnit PowerUnit { get; }
    public Ram Ram { get; }
    public Bios Bios { get; }
    public WiFiAdapter WifiAdapter { get; }
    public XmpProfile XmpProfile { get; }
    public Hsd Hsd { get; }
    public Ssd Ssd { get; }
    public VideoCard VideoCard { get; }

    public int SummOfEnergyConsumption()
    {
        return ComputerCase.PowerConsumption + Cpu.PowerConsumption + Ram.PowerConsumption +
               WifiAdapter.PowerConsumption + Hsd.PowerConsumption + Ssd.PowerConsumption + VideoCard.PowerConsumption;
    }

    public int SummOfHeatProduction()
    {
        return Cpu.HeatProduction;
    }
}