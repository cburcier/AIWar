using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWar
{
    class Robot : Element
    {
        private RobotStructure _structure;
        private Vector _direction = new Vector(0, 0);
        private Vector _forceApplied = new Vector(0,0);

        public Robot(int id):base(id,null,0)
        {
            ElemShape = new Circle(5);
            Position = new Vector(10, 20);
        }
       
        internal RobotStructure Structure { get => _structure; set => _structure = value; }
        internal Vector Direction { get => _direction; set => _direction = value; }
        internal Vector ForceApplied { get => _forceApplied;}

        public void AddForceApplied(Vector force)
        {
            _forceApplied += force;
        }

        public override void Init()
        {
            Weight = Structure.Weight;
            Structure.SetParentRobot(this);
            Structure.Init();
        }


        public bool SetStructure(RobotStructure structure)
        {
            Structure = structure;
            return true;
        }

        public virtual void Decision(double currentTime)
        {
            //TO DO
        }

        public Vector GetForceFromChangeOfDirection(double timeStep)
        {
            //// faster you go the less you can change dir and the more you will slow
            //double angleSpeedSquarePerSec = Math.PI / 4; // 90 degre per sec for a speed of 1m/sec maxAngle = coeff*time/speed^2
            //double turnDecreaseCoeff = 4 / Math.PI; //(speed decrease) acceleration = coeff * speed^2 * angle

            ////get new direction
            //double angle = Math.Acos((Direction * Speed) / (Direction.norm() * Speed.norm()));
            //double maxAngle = angleSpeedSquarePerSec * timeStep / (Speed * Speed);
            //Vector newDir = new Vector(0,0);
            //angle = Math.Min(Math.Abs(angle), maxAngle) * Math.Sign(angle);
            //newDir.x = Speed.x * Math.Cos(angle) - Speed.y * Math.Sin(angle);
            //newDir.y = Speed.x * Math.Sin(angle) + Speed.y * Math.Cos(angle);

            ////get new Speed
            //newDir *= (1 - turnDecreaseCoeff * newDir.norm() * Math.Abs(angle));

            return new Vector(0, 0);
        }

        public override Vector GetSelfForceApplied()
        {
            return ForceApplied;
        }

        public override void OnDeath()
        {
            throw new NotImplementedException();
        }

        public override void ApplyDamage(Damage d)
        {
            Structure.ApplyDamage(d);
        }

        public override void ProcessStep(double timeStep)
        {
            _forceApplied = new Vector(0,0);
            Structure.ProcessStep(timeStep);

        }
    }
}
