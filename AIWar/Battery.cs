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
            PowerMax = powerMax;
            EnergyMax = energyMax;
            Energy = EnergyMax;
        }

        public double PowerMax { get => _powerMax; set => _powerMax = value; }
        public double Energy { get => _energy; set => _energy = value; }
        public double EnergyMax { get => _energyMax; set => _energyMax = value; }
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


        public override void ProcessStep(double timeStep)
        {

        }

        public override void OnInit()
        {
            throw new NotImplementedException();
        }
    }
}
