namespace Itmo.ObjectOrientedProgramming.Lab1;

    public class EnginePulseClassC : IEnginePulse
    {
        public EnginePulseClassC()
        {
            FlowOfFuelToStart = 5;
        }

        public int FlowOfFuelToStart { get; }
    }
