using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWar
{

    class Battery : RobotElement
    {
        private double _energy;
        private double _power;
        private double _powerMax;
        private double _energyMax;

        public Battery(double powerMax, double energyMax, double healthMax, double weight) : base(healthMax, weight)
        {
            _powerMax = powerMax;
            _energyMax = energyMax;
            _energy = EnergyMax;
        }

        public double PowerMax { get => _powerMax; }
        public double Energy { get => _energy;}
        public double EnergyMax { get => _energyMax;}
        public double AvailablePower { get => _power; }

        public double UsePower(double powerNeeded)
        {
            double pow = 0;
            if (powerNeeded > _power)
                pow = _power;
            else
                pow = powerNeeded;
            _power -= pow;
            return pow;
        }


        public override void OnProcessStep(double timeStep)
        {
            _energy -= (PowerMax - _power) * timeStep;
            if (Energy <= 0)
            {
                _power = 0;
            }
            else
            {
                // TO DO : courbe de puissance
                _power = _powerMax;
            }
        }

        public override void OnInit()
        {
            throw new NotImplementedException();
        }
    }
}
