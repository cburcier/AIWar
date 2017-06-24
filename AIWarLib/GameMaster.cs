using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWar
{
    using RobotTeam = List<Robot>;

    public class GameMaster
    {
        //Config
        private double _timeStep;
        private double _gameTotalTime;
        private Universe _univ;
        double _currentTime = 0;
        bool _init = false;

        //double list for list of opponent, each opponent as a list of bot
        private List<RobotTeam> _robotsList = new List<RobotTeam>();

        public double TimeStep { get => _timeStep; }
        public double GameTotalTime { get => _gameTotalTime; }
        public bool HasInit()
        {
            return _init;
        }
        public Shape GetBoard() { return _univ.BoardShape; }

        public void Init()
        {
            //get config
            _timeStep = 0.1;
            _gameTotalTime = 600;

            //init Universe
            Rectangle shape = new Rectangle(new Vector(500, 0), new Vector(0, 300)); // FIXME faut initializer proprement !
            _univ = new Universe(shape);

            //init robot
            RobotTeam party1 = new RobotTeam();
            Robot robot1 = new Robot(1);
            robot1.Weight = 1;
            _univ.MovingElemList.Add(robot1);
            party1.Add(robot1);
            _robotsList.Add(party1);
            _init = true;
        }

        public void NextStep()
        {
            //Process decision function on robot
            foreach (RobotTeam botList in _robotsList)
            {
                foreach (Robot bot in botList)
                {
                    bot.Decision(_currentTime);
                }
            }
            _univ.ProcessStep(TimeStep);
            //Move the universe to next timeStep
            _currentTime += TimeStep;
        }

        public List<Drawable> GetDrawables()
        {
            List<Drawable> list = new List<Drawable>();
            foreach (Element elem in _univ.GetElems())
            {
                list.Add(new Drawable(elem.Id, elem.ElemShape, elem.Position));
            }
            return list;
        }

    }
}
