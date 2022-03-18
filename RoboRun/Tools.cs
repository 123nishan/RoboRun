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

    }
}
