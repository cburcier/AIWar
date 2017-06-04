using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWar
{
    class Universe
    {
        private int _usecTimeStep;
        private Dictionary<string, MovingElement> _mElem;
        private Dictionary<string, StaticElement> _sElem;

        public int UsecTimeStep { get => _usecTimeStep; set => _usecTimeStep = value; }
    }
}
