using RoboRun;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboRun
{
    public class Tools
    {





        public string[] splitCommand(String command)
        {
            string[] splitCommands = command.Split(' ');




            return splitCommands;



        }
        public string[] splitCoodinates(string[] coodinates)
        {

            string[] codinatesCommand = coodinates[1].Split(',');

            return codinatesCommand;
        }


        public Item placeRobot(Item[,] board, int x, int y, string direction)
        {

            Item item = new Item(x, y, "ROBOT", direction);

            board[x, y] = item;
            return item;
        }
        public Item placeWall(Item[,] board, int x, int y)
        {
            Item item = new Item(x, y, "WALL", "");
            board[x, y] = item;
            return item;
        }





        public string rotate(string direction, string turn)
        {
            if (turn == "LEFT")
            {
                if (direction == "NORTH")
                {
                    return "WEST";
                }
                else if (direction == "WEST")
                {
                    return "SOUTH";
                }
                else if (direction == "SOUTH")
                {
                    return "EAST";
                }
                else if (direction == "EAST")
                {
                    return "NORTH";
                }
                else
                {
                    return "INVALID";
                }
            }
            if (turn == "RIGHT")
            {
                if (direction == "NORTH")
                {
                    return "EAST";
                }
                else if (direction == "WEST")
                {
                    return "NORTH";
                }
                else if (direction == "SOUTH")
                {
                    return "WEST";
                }
                else if (direction == "EAST")
                {
                    return "SOUTH";
                }
                else
                {
                    return ("INVALID");
                }

            }
            else
            {
                return "INVALID";
            }
        }
        public int searchForRobotXPoint(Item[,] boardArr)
        {
            int point = -1;
            for (int i = 0; i < boardArr.GetLength(0); i++)
            {
                for (int j = 0; j < boardArr.GetLength(1); j++)
                {
                    string a = boardArr[i, j]?.name.Split()[0];


                    if (a != null && a == "ROBOT")
                    {
                        //Console.WriteLine("Hello im here in this function of x and value of a is " + a);

                        point = boardArr[i, j].x;

                    }
                    else
                    {

                    }



                }

            }
            return point;
        }

        public int searchForRobotYPoint(Item[,] boardArr)
        {
            int point = -1;
            for (int i = 0; i < boardArr.GetLength(0); i++)
            {
                for (int j = 0; j < boardArr.GetLength(1); j++)
                {
                    string a = boardArr[i, j]?.name;
                    //Console.WriteLine("Hello im here in this function of y and value of a is " + a);
                    if (a != null && a == "ROBOT")
                    {
                        //Console.WriteLine("Hello im here in this function of y and value of a is " + a);
                        point = boardArr[i, j].y;
                    }
                    else
                    {

                    }
                }

            }
            return point;

        }

        public string searchForRobotDirection(Item[,] boardArr)
        {
            string ans = "";
            for (int i = 0; i < boardArr.GetLength(0); i++)
            {
                for (int j = 0; j < boardArr.GetLength(1); j++)
                {
                    string a = boardArr[i, j]?.name;

                    if (a != null && a == "ROBOT")
                    {
                        ans = boardArr[i, j].direction;
                    }
                    else
                    {

                    }
                }

            }
            return ans;

        }



    }
}
