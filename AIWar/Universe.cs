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

        private List<Element> _movingElemList = new List<Element>();
        private List<Element> _staticElemList = new List<Element>();
        private CollisionManager _collisionManager ;

        public Universe()
        {
            //config
            StartReversionCoeff = 10;
            _collisionManager = new SimpleCollisionManager();
        }

        public double StartReversionCoeff { get => _startReversionCoeff; set => _startReversionCoeff = value; }

        public void ProcessStep(int timeStep)
        {
            foreach (Element elem in _movingElemList)
            {
                //get the forces
                Vector force = GetForces(elem);
                //get the next Position 
                elem.Speed = elem.Speed + elem.Weight * force * timeStep;
                elem.Position = elem.Speed * timeStep;
            }
            foreach (Element me in _movingElemList)
            {
                //check collision/damages
            }
        }

        public Vector GetForces(Element elem)
        {
            // acceleration propre de l'eleelemnt
            Vector force = elem.getSelfForceApplied();
            // frotteelemnt de demarage
            Vector startReversion = force/force.norm() * elem.Weight * Math.Exp(-elem.Speed.norm() / StartReversionCoeff);
            // frotteelemnt du terrain
            Vector frictionForce = -GetFrictionCoeff(elem) * elem.Speed * elem.Weight;
            return force+startReversion+frictionForce;
        }

        public double GetFrictionCoeff(Element elem)
        {
            // peut dependre du type de terrain (fonction de position), du type de l'element (un missile ne roule pas) etc...
            return 0;
        }
    }
}
