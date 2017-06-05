using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWar
{
    class Universe
    {
        //universe config
        private double _startReversionCoeff;

        private List<MovingElement> _mElemList = new List<MovingElement>();
        private List<StaticElement> _sElemList = new List<StaticElement>();

        public Universe()
        {
            //config
            StartReversionCoeff = 10;
        }

        public double StartReversionCoeff { get => _startReversionCoeff; set => _startReversionCoeff = value; }

        public void ProcessStep(int timeStep)
        {
            foreach (MovingElement me in _mElemList)
            {
                //get the forces
                Vector force = GetForces(me);
                //get the next Position 
                me.Speed = me.Speed + me.Weight * force * timeStep;
                me.tempPosition = me.Speed * timeStep;
            }
            foreach (MovingElement me in _mElemList)
            {
                //check collision/damages 
            }
        }

        public Vector GetForces(MovingElement me)
        {
            // acceleration propre de l'element
            Vector force = me.getSelfForceApplied();
            // frottement de demarage
            Vector startReversion = force/force.norm() * me.Weight * Math.Exp(-me.Speed.norm() / StartReversionCoeff);
            // frottement du terrain
            Vector frictionForce = -GetFrictionCoeff(me) * me.Speed * me.Weight;
            return force+startReversion+frictionForce;
        }

        public double GetFrictionCoeff(MovingElement me)
        {
            // peut dependre du type de terrain (fonction de position), du type de l'element (un missile ne roule pas) etc...
            return 0;
        }
    }
}
