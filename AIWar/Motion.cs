using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWar
{

    class Motion
    {
        static public Vector getDeltaPosition(MovingElement me, Vector forces, int usecTimeStep)
        {
            // Sum(F) = M.A
            Vector deltaSpeed = usecTimeStep * forces / me.Weight;
            Vector deltaPosition = deltaSpeed * usecTimeStep + me.Speed;
            return deltaPosition;
        }
    }
}
