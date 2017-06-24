using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWar
{
    abstract class Element : IElement
    {

        private int _id;
        private Shape _elemShape;
        private Vector _position = new Vector(0, 0);
        private Vector _prevPosition = new Vector(0, 0);
        private double _weight;
        private bool _isStatic;
        private Vector _speed = new Vector(0,0);

        public Element(int id, Shape shape, double weight)
        {
            _id = id;
            ElemShape = shape;
            Weight = weight;
            if (Weight == double.MaxValue)
            {
                IsStatic = true;
            }
        }

        public int Id { get => _id; }
        internal Vector Position
        {
            get => _position;
            set
            {
                PrevPosition = _position;
                _position = value;
            }
        }
        internal Shape ElemShape { get => _elemShape; set => _elemShape = value; }
        internal double Weight { get => _weight; set => _weight = value; }
        internal Vector Speed { get => _speed; set => _speed = value; }
        public bool IsStatic { get => _isStatic; set => _isStatic = value; }
        internal Vector PrevPosition { get => _prevPosition; set => _prevPosition = value; }

        public abstract Vector GetSelfForceApplied();

        //IElement interface
        public abstract void Init();
        public abstract void OnDeath();
        public abstract void ApplyDamage(Damage d);
        public abstract void ProcessStep(double timeStep);
    }
}
