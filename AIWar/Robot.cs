using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWar
{
    class Robot : Element
    {
        private string _name;
        private RobotStructure _structure;

        public Robot(string name):base(name,null,0)
        {
        }
       
        internal RobotStructure Structure { get => _structure; set => _structure = value; }

        public override void OnInit()
        {
            Weight = Structure.Weight;
        }


        public bool SetStructure(RobotStructure structure)
        {
            Structure = structure;
            return true;
        }

        public void Decision(double currentTimeMsec)
        {
            //TO DO
        }

        public override Vector GetSelfForceApplied()
        {
            throw new NotImplementedException();
        }

        public override void OnDeath()
        {
            throw new NotImplementedException();
        }

        public override void ApplyDamage(Damage d)
        {
            throw new NotImplementedException();
        }

        public override void ProcessStep(double timeStep)
        {
            throw new NotImplementedException();
        }
    }
}
