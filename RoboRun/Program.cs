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

                //checking to see if the command is placement command
                if (splitCommand.Length == 2)

                {

                    //splitting coodinates and assigning them to the variable
                    string[] coodinates = tools.splitCoodinates(splitCommand);
                    if (coodinates.Length == 3 || coodinates.Length == 2)
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
                        if ((commandX >= 0) && (commandX <= 4) && (commandY >= 0) && (commandY <= 4))
                        {

                            //checking if the command is to place wall or robot
                            if (splitCommand[0].ToUpper() == "PLACE_ROBOT")
                            {

                                if (commandDirection == "NORTH" || commandDirection == "SOUTH" || commandDirection == "EAST" || commandDirection == "WEST")
                                {
                                    /*
                                     * 
                                     * checking if the coodinate is empty 
                                     */
                                    if (tools.isTheLocationEmpty(boardArr, commandX, commandY) == "empty")
                                    {
                                        if (isFirstRobot == true)
                                        {
                                            if (tools.wallAhead(boardArr, commandX, commandY) == false)
                                            {
                                                tools.placeRobot(boardArr, commandX, commandY, commandDirection);
                                                isFirstRobot = false;
                                                Console.WriteLine("placing robot");
                                            }
                                            else
                                            {
                                                Console.WriteLine("wall in this location");
                                            }
                                        }
                                        //if the robot is already placed in the board
                                        else
                                        {
                                            if (tools.searchForRobotXPoint(boardArr) != -1 && tools.searchForRobotYPoint(boardArr) != -1)
                                            {

                                                int prevX = tools.searchForRobotXPoint(boardArr);
                                                int prevY = tools.searchForRobotYPoint(boardArr);
                                                string prevD = tools.searchForRobotDirection(boardArr);

                                                if (tools.wallAhead(boardArr, commandX, commandY) == false)
                                                {
                                                    tools.clearElement(boardArr, prevX, prevY);

                                                    tools.placeRobot(boardArr, commandX, commandY, prevD);

                                                    Console.WriteLine("placed on: " + boardArr[prevX, prevY].x + +boardArr[prevX, prevY].y + boardArr[prevX, prevY].direction +
                                                    boardArr[prevX, prevY].name);

                                                }
                                                else
                                                {
                                                    Console.WriteLine("wall ahead");
                                                }


                                            }

                                            Console.WriteLine("robot already in board");
                                        }
                                    }
                                    else
                                    {

                                        string currentDirection = boardArr[tools.searchForRobotXPoint(boardArr), tools.searchForRobotYPoint(boardArr)].direction.ToUpper();
                                        /*
                                         * 
                                         * 
                                         Rotate the robot
                                        */


                                        if (currentDirection == "NORTH" || currentDirection == "SOUTH")
                                        {

                                            int prevX = tools.searchForRobotXPoint(boardArr);
                                            int prevY = tools.searchForRobotYPoint(boardArr);
                                            var moveD = tools.moveNorthSouthY(prevY, currentDirection);

                                            if (tools.wallAhead(boardArr, commandX, moveD) == false)
                                            {
                                                tools.clearElement(boardArr, prevX, prevY);
                                                tools.placeRobot(boardArr, commandX, moveD, currentDirection);
                                            }
                                            else
                                            {
                                                Console.WriteLine("wall ahead");
                                            }


                                        }
                                        else if (currentDirection == "EAST" || currentDirection == "WEST")
                                        {

                                            int prevX = tools.searchForRobotXPoint(boardArr);
                                            int prevY = tools.searchForRobotYPoint(boardArr);
                                            var moveD = tools.moveEastWestX(prevX, currentDirection);
                                            if (tools.wallAhead(boardArr, moveD, commandY) == false)
                                            {
                                                tools.clearElement(boardArr, prevX, prevY);

                                                tools.placeRobot(boardArr, moveD, commandY, currentDirection);
                                            }
                                            else
                                            {
                                                Console.WriteLine("wall ahead");
                                            }

                                        }


                                    }
                                }
                                else { }
                            }
                            else if (splitCommand[0].ToUpper() == "PLACE_WALL")
                            {

                                if (tools.isTheLocationEmpty(boardArr, commandX, commandY) == "empty")
                                {
                                    if (tools.wallAhead(boardArr, commandX, commandY) == false)
                                    {
                                        tools.placeWall(boardArr, commandX, commandY);
                                    }
                                    else { Console.WriteLine("wall ahead"); }

                                }
                                else
                                {
                                    /*
                                     * if the robot is already at the location
                                     * 
                                     */



                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("inelse" + commandX);
                        }

                    }
                    else
                    {

                    }


                }
                //checking command length to break it down to place or movement command
                else if (splitCommand.Length == 1)
                {
                    if (isFirstRobot == false)
                    {
                        //for left or right movement
                        if (splitCommand[0] == "LEFT" || splitCommand[0] == "RIGHT")
                        {

                            string turned = tools.rotate(commandDirection, splitCommand[0]);
                            commandDirection = turned;

                            boardArr[commandX, commandY].direction = turned;
                            Console.WriteLine("Rotated to: " + turned);



                        }
                        /*
                         * to check current location of the robot
                         */
                        else if (splitCommand[0] == "REPORT")
                        {


                            string reportMessage = (boardArr[tools.searchForRobotXPoint(boardArr), tools.searchForRobotYPoint(boardArr)].x + 1) + "," +
                                 (boardArr[tools.searchForRobotXPoint(boardArr), tools.searchForRobotYPoint(boardArr)].y + 1) + "," +
                                 boardArr[tools.searchForRobotXPoint(boardArr), tools.searchForRobotYPoint(boardArr)].direction + "," +
                                 boardArr[tools.searchForRobotXPoint(boardArr), tools.searchForRobotYPoint(boardArr)].name;

                            Console.WriteLine(reportMessage);

                        }
                        else if (splitCommand[0] == "MOVE")
                        {
                            string currentDirection = boardArr[tools.searchForRobotXPoint(boardArr), tools.searchForRobotYPoint(boardArr)].direction;
                            if (currentDirection == "NORTH" || currentDirection == "SOUTH")
                            {

                                int prevX = tools.searchForRobotXPoint(boardArr);
                                int prevY = tools.searchForRobotYPoint(boardArr);
                                var moveD = tools.moveNorthSouthY(prevY, currentDirection);

                                if (tools.wallAhead(boardArr, commandX, moveD) == false)
                                {
                                    tools.clearElement(boardArr, prevX, prevY);
                                    tools.placeRobot(boardArr, commandX, moveD, currentDirection);
                                }
                                else
                                {
                                    Console.WriteLine("wall ahead");
                                }


                            }
                            else if (currentDirection == "EAST" || currentDirection == "WEST")
                            {

                                int prevX = tools.searchForRobotXPoint(boardArr);
                                int prevY = tools.searchForRobotYPoint(boardArr);
                                var moveD = tools.moveEastWestX(prevX, currentDirection);
                                if (tools.wallAhead(boardArr, moveD, commandY) == false)
                                {
                                    tools.clearElement(boardArr, prevX, prevY);

                                    tools.placeRobot(boardArr, moveD, commandY, currentDirection);
                                }
                                else
                                {
                                    Console.WriteLine("wall ahead");
                                }

                            }


                        }
                    }

                }
                else
                {

                }




            }


        }
    }
}