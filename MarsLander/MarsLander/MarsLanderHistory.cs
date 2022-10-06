using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsLander
{
    class MarsLanderHistory
    {
        RoundInfo[] rounds = new RoundInfo[10];
        int numRounds = 0;

        // Clone is provided to you; it'll create a copy of the current history
        // Look for opportunities to use it elsewhere.
        public MarsLanderHistory Clone()
        {
            MarsLanderHistory copy = new MarsLanderHistory();

            copy.rounds = new RoundInfo[this.rounds.Length];
            copy.numRounds = this.numRounds;
            for (int i = 0; i < copy.numRounds; i++)
                copy.rounds[i] = this.rounds[i];

            return copy;
        }
        public RoundInfo[] rounds1 = new RoundInfo[50];
        int numRounds1 = 0;
        public void AddRound(int height, int speed, int Fuel)
        {
            RoundInfo roundInfo=new RoundInfo(height,speed,Fuel);
            rounds1[numRounds1] = roundInfo;
            numRounds1++;
        }

        // you'll need other methods in order to make the PrintHistory command work
    }

    // This is provided to you; you shouldn't need to add anything to it, but
    // if you want to you are welcome to do so
    class RoundInfo
    {
        private int height;
        private int speed;
        private int Fuel;
        #region Accessors
        public int GetFuel()
        {
            return Fuel;
        }
        public void SetFuel(int newValue)
        {
            Fuel = newValue;
        }
        public int GetHeight()
        {
            return height;
        }
        public void SetHeight(int newValue)
        {
            height = newValue;
        }
        public int GetSpeed()
        {
            return speed;
        }
        public void SetSpeed(int newValue)
        {
            speed = newValue;
        }
        #endregion Accessors

        public RoundInfo(int h, int s,int f)
        {
            height = h;
            speed = s;
            Fuel = f;
        }
    }
}
