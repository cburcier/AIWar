using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWar
{
    abstract class CollisionManager
    {
        abstract public bool getCollision(Element elem1, Element elem2, ref Vector collisionPoint);
    }

    class SimpleCollisionManager : CollisionManager
    {
        public override bool getCollision(Element elem1, Element elem2, ref Vector collisionPoint)
        {
            return false;
        }
    }
}
