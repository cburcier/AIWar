using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWar
{
    using RobotTeam = List<Robot>;

    class GameMaster
    {
        //Config
        private double _timeStep;
        private double _gameTotalTime;
        private Universe _univ;

        //double list for list of opponent, each opponent as a list of bot
        private List<RobotTeam> _robotsList;

        public double TimeStep { get => _timeStep; set => _timeStep = value; }
        public double GameTotalTime { get => _gameTotalTime; set => _gameTotalTime = value; }
        internal Universe Univ { get => _univ; set => _univ = value; }

        public void runGame()
        {
            //get config
            TimeStep = 0.1;
            GameTotalTime = 600;

            //init Universe
            Rectangle shape = new Rectangle(new Vector(0,0), new Vector(0,0)); // FIXME faut initializer cproprement !
            Univ = new Universe();

            //init robot

            //run game
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

                //Move the universe to next timeStep
                currentTime += TimeStep;
            }

        }
    }
}
