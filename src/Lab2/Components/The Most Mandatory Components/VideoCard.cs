namespace Itmo.ObjectOrientedProgramming.Lab2;

public class VideoCard
{
    public VideoCard(int length, int width, string pciVersion, string frequency, int powerConsumption)
    {
        Length = length;
        Width = width;
        PCIVersion = pciVersion;
        Frequency = frequency;
        PowerConsumption = powerConsumption;
    }

    public int Length { get; }
    public int Width { get; }
    public string PCIVersion { get; }
    public string Frequency { get; }
    public int PowerConsumption { get; }
}