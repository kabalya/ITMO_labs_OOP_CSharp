using System;
namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Avgoor : ShipA
{
        private EnginePulseClassE _engine;
        private JumpEngineAlpha _jumpEngine;
        private LargeShield _shield;
        private HullStrengthLarge _hull;
        private bool _nitrinRadiator;

        public Avgoor(bool inputPhotonShield, bool nitrinRadiator, int inputlengthOfJump)
        {
            _engine = new EnginePulseClassE();
            _shield = new LargeShield(inputPhotonShield);
            _hull = new HullStrengthLarge();
            _jumpEngine = new JumpEngineAlpha(inputlengthOfJump);
            FuelCollector = new FuelCollectorClass();
            HullStrengthLarge.SetStrength();
            this._nitrinRadiator = nitrinRadiator;
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
            if (isNitrinFog && ShieldValueObject.Hp <= 0)
            {
                ShipValueObject.DeathOfCrew();
            }
            else if (isNitrinFog && ShieldValueObject.Hp > 0)
            {
                ShipValueObject.FuelIncreaser(FuelCollector.EngineCFlowInNitrinFog);
                _shield.TakeDamagePhotonShield(numberOfPhotonWays, ShieldValueObject.PhotonShield, this);
            }
        }

        public override void MoveThroughSpace(int numberOfSmallMeteorites, int numberOfBigMeteorites, int inputNumberOfWhales)
        {
            ShipValueObjects.CatchNegativeValuesMoveThroughtSpace(numberOfSmallMeteorites, numberOfBigMeteorites, inputNumberOfWhales);
            ShipValueObject.FuelIncreaser(_engine.FlowOfFuelToStart);
            ShipValueObject.FuelIncreaser(FuelCollector.EngineEFlow);

            if (ShieldValueObject.IsNitrinRadiatorActivated)
            {
                inputNumberOfWhales = 0;
            }

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
