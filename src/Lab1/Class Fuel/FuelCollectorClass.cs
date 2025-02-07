namespace Itmo.ObjectOrientedProgramming.Lab1;

public class FuelCollectorClass
    {
        public FuelCollectorClass()
        {
            EngineCFlow = 1;
            EngineCFlowInNitrinFog = 10000.0;
            EngineEFlowInNitrinFog = 1.0;
            EngineEFlow = 1.5;
            EngineJumpAlphaFlow = 4;
            EngineJumpOmegaFlow = 4 * 0.60;
            EngineJumpGammaFlow = 4 * 4;
        }

        public double EngineCFlow { get; private set; }
        public double EngineCFlowInNitrinFog { get; private set; }
        public double EngineEFlowInNitrinFog { get; private set; }
        public double EngineEFlow { get; private set; }
        public double EngineJumpAlphaFlow { get; private set; }
        public double EngineJumpOmegaFlow { get; private set; }
        public double EngineJumpGammaFlow { get; private set; }
    }
