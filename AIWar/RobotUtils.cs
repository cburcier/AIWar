using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWar
{
    abstract class RobotElement : IElement
    {
        private double _health;
        private double _healthMax;
        private double _weight;
        private double _totalWeight = -1;


        private List<RobotElement> _children;

        public RobotElement(double healthMax, double weight)
        {
            Health = healthMax;
            HealthMax = healthMax;
            _weight = weight;
        }

        public double Health { get => _health; set => _health = value; }
        public double HealthMax { get => _healthMax; set => _healthMax = value; }
        public double Weight {
            // on calcul le weight une seuke fois et on =le note.
            get
            {
                if (_totalWeight == -1)
                {
                    foreach (RobotElement e in _children)
                    {
                        _totalWeight += e.Weight;
                    }
                    _totalWeight += _weight;
                }
                return _totalWeight;
            }
        }
        internal List<RobotElement> Children { get => _children; set => _children = value; }

        public void ApplyDamage(Damage dam)
        {
            int nbVictims = Math.Min(Children.Count, dam.DiffusionFactor);
            double power = dam.Power / nbVictims;
            foreach (RobotElement victim in Tools.RamdomListPick(Children, nbVictims))
            {
                victim.ApplyDamage(new Damage(power, dam.DiffusionFactor));
            }
        }

        public Vector GetForceApplied() { return new Vector(0, 0); }
        public abstract void ProcessStep(double timeStep);
        public void OnDeath() { }
        public abstract void OnInit();
    }


    class RobotStructure : RobotElement
    {
        private Shape _elemShape; //circle wich size will determine how many RobotUtils we can stick there

        public RobotStructure(double armor, double size,double weight) : base(armor, weight)
        {
            ElemShape = new Circle(size);
        }

        internal Shape ElemShape { get => _elemShape; set => _elemShape = value; }

        public override void OnInit()
        {
            throw new NotImplementedException();
        }

        public override void ProcessStep(double timeStep)
        {
            throw new NotImplementedException();
        }
    }

    class Engine : RobotElement
    {
        double _accelerationForce;
        double _powerConsumption; //energy per sec

        public Engine(double healthMax, double weight) : base(healthMax, weight)
        {
        }

        public override void OnInit()
        {
            throw new NotImplementedException();
        }

        public override void ProcessStep(double timeStep)
        {
            throw new NotImplementedException();
        }
    }
}
