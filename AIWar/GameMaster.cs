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
        private int _timeStepMsec;
        private int _gameTotalTimeMsec;
        private Universe _univ;

        //double list for list of opponent, each opponent as a list of bot
        private List<RobotTeam> _robotsList;

        public int TimeStepMsec { get => _timeStepMsec; set => _timeStepMsec = value; }
        public int GameTotalTimeMsec { get => _gameTotalTimeMsec; set => _gameTotalTimeMsec = value; }
        internal Universe Univ { get => _univ; set => _univ = value; }

        public void runGame()
        {
            //get config
            TimeStepMsec = 100;
            GameTotalTimeMsec = 300000;

            //init Universe
            Rectangle shape = new Rectangle()
            Univ = new Universe(shape);

            //init robot

            //run game
            int currentTime = 0;
            for (int i = 0; i < GameTotalTimeMsec / TimeStepMsec; ++i)
            {
                //Process decision function on robot
                foreach (RobotParty botList in _robotsList)
                {
                    foreach (Robot bot in botList)
                    {
                        bot.decision(currentTime);
                    }
                }

                //Move the universe to next timeStep
                Universe.

                currentTime += TimeStepMsec;
            }

        }
    }
}
