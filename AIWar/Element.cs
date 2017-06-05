using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWar
{
    abstract class Element
    {
        
        private iShape _shape;
        private string _name;
        private Vector _position;

        public Element(string name, iShape shape)
        {
            Name = name;
            Shape = shape;
        }

        internal iShape Shape { get => _shape; set => _shape = value; }
        public string Name { get => _name; set => _name = value; }
        internal Vector Position { get => _position; set => _position = value; }
    }

    abstract class StaticElement : Element
    {
        public StaticElement(string name, iShape shape) : base(name, shape) { }
    }

    abstract class MovingElement : Element
    {
        public Vector tempPosition;
        private double _weight;
        private Vector _speed;
        
        public MovingElement(string name, iShape shape, double weight) : base(name, shape)
        {
            Weight = weight;
        }

        public abstract Vector getSelfForceApplied();

        internal double Weight { get => _weight; set => _weight = value; }
        internal Vector Speed { get => _speed; set => _speed = value; }
    }
}
