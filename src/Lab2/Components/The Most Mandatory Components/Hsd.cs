namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Hsd
{
    public Hsd(int capacity, int maxSpeedOfStick, int powerConsumption)
    {
        Capacity = capacity;
        MaxSpeedOfStick = maxSpeedOfStick;
        PowerConsumption = powerConsumption;
    }

    public int Capacity { get; }
    public int MaxSpeedOfStick { get; }
    public int PowerConsumption { get; }
}