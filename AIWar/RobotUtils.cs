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
        private Robot _parentRobot;
        private List<RobotElement> _children;
        private Battery _batteryPluged;

        public RobotElement(double healthMax, double weight)
        {
            Health = healthMax;
            HealthMax = healthMax;
            _weight = weight;
        }

        public void SetParentRobot(Robot parent)
        {
            _parentRobot = parent;
            foreach(RobotElement re in Children)
            {
                re.SetParentRobot(parent);
            }
        }

        public double Health { get => _health; set => _health = value; }
        public double HealthMax { get => _healthMax; set => _healthMax = value; }
        public double Weight {
            get
            {
                double totalWeight = 0;
                foreach (RobotElement e in _children)
                {
                    totalWeight += e.Weight;
                }
                totalWeight += _weight;
                return totalWeight;
            }
        }
        internal List<RobotElement> Children { get => _children; set => _children = value; }
        internal Battery BatteryPluged { get => _batteryPluged; set => _batteryPluged = value; }
        internal Robot ParentRobot { get => _parentRobot;}

        public void PlugBattery(Battery battery)
        {
            BatteryPluged = battery;
        }

        // IElement Interface
        public void ApplyDamage(Damage dam)
        {
            int nbVictims = Math.Min(Children.Count, dam.DiffusionFactor);
            double power = dam.Power / nbVictims;
            foreach (RobotElement victim in Tools.RamdomListPick(Children, nbVictims))
            {
                victim.ApplyDamage(new Damage(power, dam.DiffusionFactor));
            }
        }
        public void Init()
        {
            //Comon init and checks
            if (ParentRobot==null)
            {
                //raise Error
            }
            // specific init
            OnInit();
            //passe passe le oinj... l'init
            foreach (RobotElement re in Children)
            {
                Init();
            }
        }
        public void ProcessStep(double timeStep)
        {
            OnProcessStep(timeStep);
            foreach (RobotElement re in Children)
            {
                ProcessStep(timeStep);
            }
        }
        public void OnDeath() { }

        public abstract void OnProcessStep(double timeStep);
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
            //TO DO
        }

        public override void OnProcessStep(double timeStep)
        {
            //TO DO
        }
    }

    class Engine : RobotElement
    {
        private double _maxPower;
        private double _efficiency; //in Pct
        private double _power; //this will be a variable accessible from the user code

        public Engine(double healthMax, double weight, double maxPower, double efficiency) : base(healthMax, weight)
        {
            _maxPower = maxPower;
            _efficiency = efficiency;
        }

        public double MaxPower { get => _maxPower; }
        public double Power { get => _power; set => _power = value; }
        public double Efficiency { get => _efficiency;}

        public override void OnInit()
        {
            if (BatteryPluged==null)
            {
                //TO DO raise warning
            }
        }

        public override void OnProcessStep(double timeStep)
        {
            double powerAvailable = BatteryPluged.UsePower(Power);
            ParentRobot.AddForceApplied(ParentRobot.Direction * powerAvailable * Efficiency);
        }
    }
}
