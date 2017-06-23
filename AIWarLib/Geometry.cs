using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace AIWar
{
    public class Vector
    {
        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public double x;
        public double y;
        public double norm()
        {
            return Math.Sqrt(x * x + y * y);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x+v2.x,v1.y+v2.y);
        }

        public static double operator *(Vector v1, Vector v2)
        {
            return v1.x * v2.x + v1.y * v2.y;
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

        public static Vector operator /(double m,Vector v)
        {
            return new Vector(v.x / m, v.y / m);
        }
    }

    public abstract class Shape
    {
    }

    public class Rectangle : Shape
    {
        private Vector _w;
        private Vector _h;

        public Rectangle(Vector w,Vector h)
        {
            W = w;
            H = h;
        }

        public Vector W { get => _w; set => _w = value; }
        public Vector H { get => _h; set => _h = value; }
    }

    public class Circle : Shape
    {
        private double _radius;

        public Circle(double radius)
        {
            Radius = Radius;
        }

        public double Radius { get => _radius; set => _radius = value; }
    }
}
