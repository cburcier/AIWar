using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWar
{
    class Vector
    {
        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        double x;
        double y;
        public double norm()
        {
            return Math.Sqrt(x * x + y * y);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x+v2.x,v1.y+v2.y);
        }

        public static Vector operator *(double m,Vector v)
        {
            return new Vector(v.x * m, v.y * m);
        }

        public static Vector operator *(Vector v, double m)
        {
            return new Vector(v.x * m, v.y * m);
        }

        public static Vector operator /(Vector v, double m)
        {
            return new Vector(v.x / m, v.y / m);
        }
    }

    abstract class Shape
    {
    }

    class Rectangle : Shape
    {
        private Vector _l;
        private Vector _w;

        Rectangle(Vector l,Vector w)
        {
            L = l;
            W = w;
        }

        internal Vector W { get => _w; set => _w = value; }
        internal Vector L { get => _l; set => _l = value; }
    }

    class Circle : Shape
    {
        private double _radius;

        public double Radius { get => _radius; set => _radius = value; }
    }
}
