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

        //double list for list of opponent, each opponent as a list of bot
        private List<RobotTeam> _robotsList;

        public double TimeStep { get => _timeStep; }
        public double GameTotalTime { get => _gameTotalTime; }
        public Shape GetBoard() { return _univ.BoardShape; }

        public void Init()
        {
            //get config
            _timeStep = 0.1;
            _gameTotalTime = 600;

            //init Universe
            Rectangle shape = new Rectangle(new Vector(100, 0), new Vector(0, 100)); // FIXME faut initializer proprement !
            _univ = new Universe(shape);

            //init robot

        }

        public void RunGame()
        {
            double currentTime = 0;
            for (int i = 0; i < GameTotalTime / TimeStep; ++i)
            {
                //Process decision function on robot
                foreach (RobotTeam botList in _robotsList)
                {
                    foreach (Robot bot in botList)
                    {
                        bot.Decision(currentTime);
                    }
                }
                _univ.ProcessStep(TimeStep);
                //Move the universe to next timeStep
                currentTime += TimeStep;
            }
        }

        public void ObserverSubscribe(IUniverseObserver obs)
        {
            _univ.ObserverSubscribe(obs);
        }

    }
}
