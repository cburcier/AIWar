using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWar
{
    class Element
    {
        public Element(string name, iShape shape)
        {
            Name = name;
            Shape = shape;
        }
        private iShape _shape;
        private string _name;
        private Vector _position;

        internal iShape Shape { get => _shape; set => _shape = value; }
        public string Name { get => _name; set => _name = value; }
    }

    class StaticElement : Element
    {
        public StaticElement(string name, iShape shape) : base(name, shape) { }
    }

    class MovingElement : Element
    {
        public MovingElement(string name, iShape shape, double weight) : base(name, shape)
        {
            Weight = weight;
        }
        private double _weight;
        private Vector _speed;

        internal double Weight { get => _weight; set => _weight = value; }
        internal Vector Speed { get => _speed; set => _speed = value; }
    }
}
