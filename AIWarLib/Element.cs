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
        private Vector _position;
        private Vector _prevPosition;
        private double _weight;
        private bool _isStatic;
        private Vector _speed;
        private List<IUniverseObserver> _observerList;

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

        public int Id { get => Id; }
        internal Vector Position
        {
            get => _position;
            set
            {
                PrevPosition = _position;
                _position = value;
                foreach (IUniverseObserver obs in _observerList)
                {
                    obs.UpdateDrawable(GetDrawable());
                }
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

        public Drawable GetDrawable()
        {
            return new Drawable(Id, ElemShape, Position, DrawableType.full);
        }

        public void ObserverSubscribe(IUniverseObserver obs)
        {
            _observerList.Add(obs);
            obs.UpdateDrawable(GetDrawable());
        }
    }
}
