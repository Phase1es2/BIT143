using System;

namespace Helpdesk
{
    class UserInterface
    {
        public void RunProgram()
        {
            History browserHistory = new History();

            bool fContinue = true;
            string desc; // description of problem, for inputting new problems

            while (fContinue)
            {
                int userChoice = -1;
                while (userChoice < 1 || userChoice > 5)
                {
                    Console.WriteLine(); // visual spacer
                    Console.WriteLine(" Your options are:");
                    Console.WriteLine("1) View your history");
                    Console.WriteLine("2) Move 1 page backwards in your 'browser history'");
                    Console.WriteLine("3) Move 1 page forwards in your 'browser history'");
                    Console.WriteLine("4) Visit a new page");
                    Console.WriteLine("5) Quit");
                    Console.Write("Type in your choice here:");
                    if (!Int32.TryParse(Console.ReadLine(), out userChoice))
                    {
                        Console.WriteLine("You need to type in a number!");
                    }
                    Console.WriteLine(); // visual spacer
                }

                switch (userChoice)
                {
                    case 1:
                        browserHistory.PrintAll();
                        break;
                    case 2:
                        Console.WriteLine("Moving backwards in your (browser) history:");
                        browserHistory.MoveBackwards();
                        browserHistory.PrintAll();
                        break;
                    case 3:
                        Console.WriteLine("Moving forwards in your (browser) history:");
                        browserHistory.MoveForwards();
                        browserHistory.PrintAll();
                        break;
                    case 4:
                        Console.WriteLine("What page are you visiting?");
                        String pg = Console.ReadLine();
                        browserHistory.VisitPage(pg);
                        browserHistory.PrintAll();
                        break;
                    case 5:
                        Console.WriteLine("Thanks for using the program!\nGoodbye!\n\n");
                        Console.WriteLine("<Press the enter key to exit>");
                        Console.ReadLine();
                        return;
                }
            }
        }
    }
}
