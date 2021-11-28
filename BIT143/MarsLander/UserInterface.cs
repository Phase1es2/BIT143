using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MarsLander
{
    class UserInterface
    {
        public void PrintGreeting()
        {
            Console.WriteLine("Welcome to the Mars Lander game!");
        }

        // This should print the 'picture' of hte lander
        // for example:
        //      1000m: *
        //      900m: 
        //      800m:
        // etc, etc
        public void PrintLocation(MarsLander marsLander)
        {
            int height= marsLander.roundInfo.GetHeight();
            int speed= marsLander.roundInfo.GetSpeed();
            if (height > 1000)
            {
                int count = height / 100;
                for (int i = count; i >= 0; i--)
                {
                    if (i == count)
                    {
                        Console.WriteLine(i * 100 + "m:*");
                    }
                    else
                    {
                        Console.WriteLine(i * 100 + "m:");
                    }
                }
            }
            else
            {
                int count = 1000 / 100;
                for (int i = count; i >= 0; i--)
                {
                    if (i == height/100)
                    {
                        Console.WriteLine(i * 100 + "m:*");
                    }
                    else
                    {
                        Console.WriteLine(i * 100 + "m:");
                    }
                }
            }
            
            Console.WriteLine();
        }

        // This prints out the info about the lander
        // For example:
        //      Exact height: 1350 meters
        //      Current (downward) speed: -350 meters/second
        //      Fuel points left: 0
        public void PrintLanderInfo(MarsLander marsLander)
        {
            int height = marsLander.roundInfo.GetHeight();
            int speed = marsLander.roundInfo.GetSpeed();
            int Fuel = marsLander.roundInfo.GetFuel();
            Console.WriteLine("Exact height: "+height+" meters");
            Console.WriteLine("Current (downward) speed: "+speed+" meters/second");
            Console.WriteLine(" Fuel points left: "+ Fuel);
            Console.WriteLine();
        }

        // This will ask the user for how much fuel they want to burn,
        // verify that they've type in an acceptable integer,
        //  (repeatedly asking the user for input if needed),
        // and will then return that number back to the main method
        public int GetFuelToBurn(MarsLander marsLander)
        {
            int Fuel = marsLander.roundInfo.GetFuel();
            Console.WriteLine("How many points of fuel would you like to burn?");
            string s= Console.ReadLine();
             int result;
             if (int.TryParse(s, out result))
             {
                 if (result < 0)
                 {
                     Console.WriteLine("You can't burn less than 0 points of fuel!");
                     GetFuelToBurn(marsLander);
                 }
                 else if (result > Fuel)
                 {
                     Console.WriteLine("You don't have "+result+" points of fuel!");
                     GetFuelToBurn(marsLander);
                 }
                 else
                 {
                     return result;
                 }
             }
             else
             {
                 Console.WriteLine("You need to type a whole number of fuel points to burn!");
                 GetFuelToBurn(marsLander);
             }
            // Here are some useful print statements that you'll need:

            //Console.WriteLine("You can't burn less than 0 points of fuel!");
            //Console.WriteLine("You don't have {0} points of fuel!", nFuel);
            //Console.WriteLine("You need to type a whole number of fuel points to burn!");

            //Console.WriteLine();
            //Console.WriteLine("Just as a reminder, here's where the lander is: ");
            //PrintLanderInfo(ml);
            //Console.WriteLine("How many points of fuel would you like to burn?");
            //Console.WriteLine();

            return 0;
        }

        // This will only be called once the lander is on the surface of Mars, 
        //  and will tell the player if they successly landed or if they crashed
        public void PrintEndOfGameResult(MarsLander ml, int maxSpeed)
        {
            if (ml.roundInfo.GetSpeed() > maxSpeed)
            {
                Console.WriteLine("The maximum speed for a safe landing is 10; your lander's current speed is"+ ml.roundInfo.GetSpeed());
                Console.WriteLine(" You have crashed the lander into the surface of Mars, killing everyone on board,");
                Console.WriteLine(" costing NASA millions of dollars, and setting the space program back by decades!");
                Console.WriteLine("Here's the height/speed info for you:");
            }
            else
            {
                Console.WriteLine("Congratulations!! You've successfully landed your Mars Lander, without crashing!!!");
                Console.WriteLine("Here's the height/speed info for you:");
            }
            PrintHistory(ml.GetHistory());
        }
        
        // This will print out, for example: 
        //      Round # 	Height (in m) 	Speed (downwards, in m/s)
        //      0 		850 		150
        //      1 		650 		200
        //  etc
        //
        // This is provided to you, but you'll need to add stuff elsewhere in order to make it work 
        public void PrintHistory(RoundInfo[] mlh)
        {
            Console.WriteLine("Round #\t\tHeight (in m)\t\tSpeed (downwards, in m/s)");
            for (int i = 0; i < mlh.Length; i++)
            {
                if (mlh[i] != null)
                {
                    if (mlh[i].GetHeight() <= 0)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}", i, 0, mlh[i].GetSpeed());
                    }
                    else
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}", i, mlh[i].GetHeight(), mlh[i].GetSpeed());
                    }
                   
                }
            }
        }
    }
}
