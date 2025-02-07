namespace Itmo.ObjectOrientedProgramming.Lab2;

public interface IComputerBuilder
{
    public ComputerBuilder AddComputerCase(ComputerCase computerCase);
    public ComputerBuilder AddCooler(Cooler cooler);
    public ComputerBuilder AddCpu(Cpu cpu);
    public ComputerBuilder AddMotherBoard(MotherBoard motherBoard);
    public ComputerBuilder AddPowerUnit(PowerUnit powerUnit);
    public ComputerBuilder AddRam(Ram ram);
    public ComputerBuilder AddBios(Bios bios);
    public ComputerBuilder AddWifiAdapter(WiFiAdapter wiFi);
    public ComputerBuilder AddXmpProfile(XmpProfile xmpProfile);
    public ComputerBuilder AddHsd(Hsd hsd);
    public ComputerBuilder AddSsd(Ssd ssd);
    public ComputerBuilder AddVideocard(VideoCard videocard);
    public ComputerBuilder AddAllComponents(ComputerCase computerCase, Cooler cooler, Cpu cpu, MotherBoard motherBoard, PowerUnit powerUnit, Ram ram, Bios bios, WiFiAdapter wiFi, XmpProfile xmpProfile, Hsd hsd, Ssd ssd, VideoCard videocard);
    public Computer Build();
}