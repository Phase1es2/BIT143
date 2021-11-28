using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsLander
{
    class MarsLander
    {
        // positive speed == speed towards Mars (DOWNWARD)

        private MarsLanderHistory mlh = new MarsLanderHistory();
        public  RoundInfo roundInfo=new RoundInfo(1000,100,500);
        // you'll need to add data fields & methods so that the rest of the program
        // can use the various properties of the lander (such as height, speed, etc)
        public void CalculateNewSpeed(int result)
        {
            int remainoil = roundInfo.GetFuel() - result;
            int speed = (roundInfo.GetSpeed() + 50) - result * 1;
            int height = roundInfo.GetHeight() - speed;
            roundInfo.SetFuel(remainoil);
            roundInfo.SetHeight(height);
            roundInfo.SetSpeed(speed);
            mlh.AddRound(height,speed,remainoil);
        }
        public MarsLander()
        {
           
        }

        public RoundInfo[] GetHistory()
        {
            return mlh.rounds1;
        }

    }
}
