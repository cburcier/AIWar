using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWar
{
    class Robot
    {
        public Robot(string name)
        {
            Name = name;
        }
        private string _name;

        public string Name { get => _name; set => _name = value; }

        public void decision(int currentTimeMsec)
        {

        }
    }
}
