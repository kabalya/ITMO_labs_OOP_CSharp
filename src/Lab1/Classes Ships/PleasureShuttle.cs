using System;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class PleasureShuttle : ShipA
    {
        private EnginePulseClassC _engine;
        private NoJumpEngine _jumpEngine;
        private NoShield _shield;
        private HullStrengthSmall _hull;

        public PleasureShuttle()
        {
            _engine = new EnginePulseClassC();
            _shield = new NoShield();
            _hull = new HullStrengthSmall();
            _jumpEngine = new NoJumpEngine();
            FuelCollector = new FuelCollectorClass();
            HullStrengthSmall.SetStrength();
            ShipValueObject = new ShipValueObjects();
            ShieldValueObject = new ShieldValueObjects();
            JumpEngineValueObject = new JumpEngineValueObjects();
        }

        public FuelCollectorClass FuelCollector { get; private set; }
        public ShipValueObjects ShipValueObject { get; }
        public new ShieldValueObjects ShieldValueObject { get; }
        public JumpEngineValueObjects JumpEngineValueObject { get; }

        public void MoveInNitrinFog(bool isNitrinFog, int numberOfPhotonWays, bool photonShield)
        {
            ShipValueObjects.CatchNegativeValuesMoveInFog(numberOfPhotonWays);
            ShieldValueObject.SetPhotonShield(photonShield);
            if (numberOfPhotonWays > 0 && isNitrinFog == false)
            {
                throw new InvalidOperationException("Wrong values");
            }

            if (isNitrinFog && numberOfPhotonWays > 0)
            {
                ShipValueObject.DeathOfCrew();
            }
        }

        public override void MoveThroughSpace(int numberOfSmallMeteorites, int numberOfBigMeteorites, int inputNumberOfWhales)
        {
            ShipValueObjects.CatchNegativeValuesMoveThroughtSpace(numberOfSmallMeteorites, numberOfBigMeteorites, inputNumberOfWhales);
            ShipValueObject.FuelIncreaser(_engine.FlowOfFuelToStart);
            ShipValueObject.FuelIncreaser(FuelCollector.EngineEFlow);

            ShieldValueObject.TakeDamage(ShieldValueObject.CalculateTotalDamage(numberOfSmallMeteorites,  numberOfBigMeteorites,  inputNumberOfWhales));
            _hull.TakeDamage(ShieldValueObject.RemainingDamage);

            if (HullValueObjects.Strength <= 0)
            {
                ShipValueObject.DieOfShip();
            }
        }
    }