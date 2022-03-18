using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboRun
{
    public class Program
    {
        static void Main(string[] args)
        {
            Tools tools = new Tools();
            //creating 2D arr for board of size 5x5
            Item[,] boardArr = new Item[5, 5];

            //flag to check if the robot is placed
            Boolean isFirstRobot = true;
            int commandX = -1, commandY = -1;
            string commandDirection = "";
            Console.WriteLine("=============================ROBOT SIMULATOR=======================================");
            Console.WriteLine("Commands:");
            Console.WriteLine("PLACE_ROBOT X,Y,DIRECTION[NORTH,SOUTH,EAST,WEST]");
            Console.WriteLine("PLACE_WALL X,Y");
            Console.WriteLine("REPORT");
            Console.WriteLine("MOVE");
            Console.WriteLine("LEFT");
            Console.WriteLine("RIGHT");
            Console.WriteLine("===================================================================================");

            bool running = true;
            while (running)
            {
                /*
                 * spliting string to process the command
                 */
                Console.WriteLine("Enter the command");
                string command = Console.ReadLine().ToUpper();
  
                string[] splitCommand = tools.splitCommand(command);

                /*
                 * extracting coodinates from the command
                 */
            
                string[] coodinates = tools.splitCoodinates(splitCommand);
                //checking to see if the command is placement command
                if (splitCommand.Length == 2)

                {

                    try
                    {
                        commandX = Int32.Parse(coodinates[0]) - 1;
                        commandY = Int32.Parse(coodinates[1]) - 1;
                    }
                    catch { }
                    if (coodinates.Length == 3)
                    {
                        commandDirection = coodinates[2].ToUpper();
                    }


                }


                }
        }
    }
}
