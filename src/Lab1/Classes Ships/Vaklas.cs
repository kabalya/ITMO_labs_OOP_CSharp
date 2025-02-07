using System;
namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Vaklas : ShipA
    {
        private EnginePulseClassE _engine;
        private JumpEngineGamma _jumpEngine;
        private SmallShield _shield;
        private HullStrengthSmall _hull;
        private bool _nitrinRadiator;

        public Vaklas(bool inputPhotonShield, bool nitrinRadiator, int inputlengthOfJump)
        {
            _engine = new EnginePulseClassE();
            _shield = new SmallShield(inputPhotonShield);
            _hull = new HullStrengthSmall();
            _jumpEngine = new JumpEngineGamma(inputlengthOfJump);
            FuelCollector = new FuelCollectorClass();
            this._nitrinRadiator = nitrinRadiator;
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
            if (isNitrinFog == true && ShieldValueObject.Hp <= 0)
            {
                ShipValueObject.DeathOfCrew();
            }
            else if (isNitrinFog && ShieldValueObject.Hp > 0)
            {
                ShipValueObject.FuelIncreaser(FuelCollector.EngineCFlowInNitrinFog);
                _shield.TakeDamagePhotonShield(numberOfPhotonWays, photonShield, this);
            }
        }

        public override void MoveThroughSpace(int numberOfSmallMeteorites, int numberOfBigMeteorites, int inputNumberOfWhales)
        {
            ShipValueObjects.CatchNegativeValuesMoveThroughtSpace(numberOfSmallMeteorites, numberOfBigMeteorites, inputNumberOfWhales);
            ShipValueObject.FuelIncreaser(_engine.FlowOfFuelToStart);
            if (ShieldValueObject.IsNitrinRadiatorActivated == true)
            {
                inputNumberOfWhales = 0;
            }

            ShipValueObject.FuelIncreaser(FuelCollector.EngineEFlow);
            if (ShieldValueObject.CalculateTotalDamage(numberOfSmallMeteorites,  numberOfBigMeteorites,  inputNumberOfWhales) < 0)
            {
                throw new InvalidOperationException("Length Can not be -Value");
            }
            else if (ShieldValueObject.CalculateTotalDamage(numberOfSmallMeteorites,  numberOfBigMeteorites,  inputNumberOfWhales) > 3000)
            {
                ShipValueObject.DieOfShip();
            }

            ShieldValueObject.TakeDamage(ShieldValueObject.CalculateTotalDamage(numberOfSmallMeteorites,  numberOfBigMeteorites,  inputNumberOfWhales));
            _hull.TakeDamage(ShieldValueObject.RemainingDamage);

            if (HullValueObjects.Strength <= 0)
            {
                ShipValueObject.DieOfShip();
            }
        }
    }