namespace Itmo.ObjectOrientedProgramming.Lab1;

public class EnginePulseClassE : IEnginePulse
{
    public EnginePulseClassE()
    {
        FlowOfFuelToStart = 10;
    }

    public int FlowOfFuelToStart { get; }
}
