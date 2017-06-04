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

    interface iShape
    {}

    class Cuboid : iShape
    {
        Cuboid(Vector dims)
        {
            Dims = Dims;
        }
        private Vector _dims;

        internal Vector Dims { get => _dims; set => _dims = value; }
    }
}
