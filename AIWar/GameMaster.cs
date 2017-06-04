using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWar
{
    using RobotParty = List<Robot>;

    class GameMaster
    {
        //Config
        private int _timeStepMsec;
        private int _gameTotalTimeMsec;

        //double list for list of opponent, each opponent as a list of bot
        private List<RobotParty> _robotsList;

        public int TimeStepMsec { get => _timeStepMsec; set => _timeStepMsec = value; }
        public int GameTotalTimeMsec { get => _gameTotalTimeMsec; set => _gameTotalTimeMsec = value; }

        public void runGame()
        {
            //get config
            TimeStepMsec = 100;
            GameTotalTimeMsec = 300000;

            //init elem

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

                currentTime += TimeStepMsec;
            }

        }
    }
}
