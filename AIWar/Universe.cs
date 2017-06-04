using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWar
{
    class Universe
    {
        private List<MovingElement> _mElemList;
        private List<StaticElement> _sElemList;

        public void processStep()
        {
            foreach (MovingElement me in _mElemList)
            {
                //get the forces 
                //get the next Position 
                //check collision/damages 
                //update speed
            }
            
        }
    }
}
