namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Ssd
{
    public Ssd(bool isConnectionSata, int capacity, int maxSpeedOfWork, int powerConsumption)
    {
        IsConnectionSata = isConnectionSata;
        Capacity = capacity;
        MaxSpeedOfWork = maxSpeedOfWork;
        PowerConsumption = powerConsumption;
    }

    public bool IsConnectionSata { get; }
    public int Capacity { get; }
    public int MaxSpeedOfWork { get; }
    public int PowerConsumption { get; }
}